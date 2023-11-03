using Api.Reservation.Business.Models;
using Api.Reservation.Business.Service;
using Api.Reservation.Datas.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.utilisateur.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilisateursController : ControllerBase
    {

        /// <summary>
        /// The utilisateur service
        /// </summary>
        private readonly IUtilisateurService _utilisateurService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UtilisateursController"/> class.
        /// </summary>
        /// <param name="utilisateurService">The utilisateur service.</param>
        public UtilisateursController(IUtilisateurService utilisateurService)
        {
            _utilisateurService = utilisateurService;
        }


        // GET: api/Utilisateurs
        [HttpGet]
        public async Task<IActionResult> GetUtilisateursAsync()
        {
            return Ok(await _utilisateurService.GetUtilisateursAsync());
        }

        // GET api/<UtilisateursController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUtilisateurByIdAsync(int id)
        {
            return Ok(await _utilisateurService.GetUtilisateurByIdAsync(id));
        }

        // POST api/Utilisateurs
        [HttpPost]
        public async Task<IActionResult> CreateUtilisateurAsync([FromBody] CreateUtilisateurDto utilisateur)
        {
            try
            {
                var utilisateurToCreate = new Utilisateur()
                {
                    Nom = utilisateur.Nom,
                    Prenom = utilisateur.Prenom,
                    Email = utilisateur.Email,
                    DateNaissance = utilisateur.DateNaissance
                };

                return Ok(await _utilisateurService.CreateUtilisateurAsync(utilisateurToCreate));
            }
            catch (Exception e) { return Problem(e.Message, e.StackTrace); }
        }

        // PUT api/<UtilisateursController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            var userToUpdate = new Datas.Entities.Utilisateur()
            {
                Nom = value.Nom,
                Prenom = value.Prenom,
                Email = value.Email,
                DateNaissance = value.DateNaissance
            };
            _utilisateurService.UpdateUtilisateurAsync(id, userToUpdate);
        }

        // DELETE api/<UtilisateursController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var usersReservations = await _reservationService.GetReservationsByUtilisateurAsync(id);
            if (usersReservations.Count > 0)
            {
                foreach (var reservation in usersReservations)
                {
                    await _reservationService.DeleteReservationByIdAsync(reservation.Id);
                }
            }
            await _utilisateurService.DeleteUtilisateurAsync(id);
        }
    }
}
