using Api.Reservation.Business.Models;
using Api.Reservation.Datas.Entities;
//using Api.Utilisateur.Datas.Repository;
using Api.Reservation.Datas.Repository;
using Api.Reservation.Generals.Common;
using Refit;


namespace Api.Reservation.Business.Service
{
    public class UtilisateurService : IUtilisateurService
    {
        /// <summary>
        /// The utilisateur repository
        /// </summary>
        private readonly IUtilisateurRepository _utilisateurRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReservationService"/> class.
        /// </summary>
        /// <param name="utilisateurRepository">The utilisateur repository.</param>
        public UtilisateurService(IUtilisateurRepository utilisateurRepository)
        {
            _utilisateurRepository = utilisateurRepository;
        }

        /// <summary>
        /// Cette méthode permet de recupérer la liste des utilisateurs
        /// </summary>
        /// <returns></returns>
        public async Task<List<Datas.Entities.Utilisateur>> GetUtilisateursAsync()
        {
            return await _utilisateurRepository.GetUtilisateursAsync()
                .ConfigureAwait(false);
        }


        /// <summary>
        /// Creates the utilisateur asynchronous.
        /// </summary>
        /// <param name="utilisateur">The utilisateur.</param>
        /// <returns></returns>
        /// <exception cref="Api.Reservation.Generals.Common.BusinessException">Echec de création d'un utilisateur : L'utilisateur existe deja.</exception>
        public async Task<Datas.Entities.Utilisateur> CreateUtilisateurAsync(Datas.Entities.Utilisateur utilisateur)
        {
            // Vérifier l'existence de l'email utilisateur ,s'il existe on lève une exepction 
            /*var emailStatus = await GetEmailStatusAsync(utilisateur.Email);*/

            List<Utilisateur> utilisateurs = await GetUtilisateursAsync();
            foreach(Utilisateur user in utilisateurs)
            {
                if (user.Email == utilisateur.Email)
                {
                    throw new BusinessException("Echec de création d'un utilisateur : L'email n'est pas disponible.");
                }
            }

            // L'email est disponible, procédez à la création de l'utilisateur
            return await _utilisateurRepository.CreateUtilisateurAsync(utilisateur)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Cette méthode permet de recupérer un utilisateur
        /// </summary>
        /// <returns></returns>
        public async Task<Datas.Entities.Utilisateur> GetUtilisateurByIdAsync(int id)
        {
            return await _utilisateurRepository.GetUtilisateurByIdAsync(id)
                .ConfigureAwait(false);
        }

        public async Task DeleteUtilisateurAsync(int id)
        {
            await _utilisateurRepository.DeleteUtilisateurAsync(id);
        }



        /*/// <summary>
        /// Initializes a new instance of the <see cref="UtilisateurService"/> class.
        /// </summary>
        /// <param name="utilisateurRepository">The utilisateur repository.</param>        
        public async Task<Datas.Entities.Reservation> GetEmailStatusAsync(string email)
        {
            return await _utilisateurRepository.GetEmailStatusAsync(Email)
                .ConfigureAwait(false);
        }
        

        /// <summary>
        /// Creates the utilisateur asynchronous.
        /// </summary>
        /// <param name="utilisateur">The utilisateur.</param>
        /// <returns></returns>
        /// <exception cref="Api.Reservation.Generals.Common.BusinessException">Echec de création d'un utilisateur : L'utilisateur existe deja.</exception>
        public async Task<Datas.Entities.Reservation> CreateUtilisateurAsync(Datas.Entities.Reservation utilisateur)
        {
            // Vérifier l'existence de l'email utilisateur ,s'il existe on lève une exepction 
            var emailStatus = await GetEmailStatusAsync(utilisateur.Email);

            if (emailStatus?.Status != "Disponible")
            {
                throw new BusinessException("Echec de création d'un utilisateur : L'email n'est pas disponible.");
            }

            // L'email est disponible, procédez à la création de l'utilisateur
            return await _utilisateurRepository.CreateUtilisateurAsync(utilisateur)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Cette méthode permet de recupérer la liste des utilisateurs
        /// </summary>
        /// <returns></returns>
        public async Task <List<Datas.Entities.Reservation>> GetUtilisateursAsync()
        {
            return await _utilisateurRepository.GetUtilisateursAsync()
                .ConfigureAwait(false);
        }
        

        // test boolean 
        // public bool mailDejaUtilise (string email)
        // {
        //     return _context.Utilisateur.Any(u)
        // }*/
    }
}