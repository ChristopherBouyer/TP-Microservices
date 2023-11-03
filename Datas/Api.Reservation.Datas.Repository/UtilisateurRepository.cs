using Api.Reservation.Datas.Context;
using Microsoft.EntityFrameworkCore;

namespace Api.Reservation.Datas.Repository
{
    public class UtilisateurRepository : IUtilisateurRepository
    {

        /// <summary>
        /// The context
        /// </summary>
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UtilisateurRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public UtilisateurRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Cette méthode permet de recupérer la liste des utilisateurs
        /// </summary>
        /// <returns></returns>
        public async Task<List<Entities.Utilisateur>> GetUtilisateursAsync()
        {
            return await _context.Utilisateurs
                .ToListAsync()
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Cette methode permet de créer un nouvel utilisateur.
        /// </summary>
        /// <param name="utilisateur">Les informations d'un nouvel utilisateur</param>
        /// <returns></returns>
        public async Task<Entities.Utilisateur> CreateUtilisateurAsync(Entities.Utilisateur utilisateur)
        {
            await _context.Utilisateurs.AddAsync(utilisateur);
            await _context.SaveChangesAsync();
            return utilisateur;
        }

        /// <summary>
        /// Cette méthode permet de recupérer les utilisateurs par l'id
        /// </summary>
        /// <param name="id">l'id.</param>
        /// <returns></returns>
        public async Task<Entities.Utilisateur> GetUtilisateurByIdAsync(int id)
        {
            /* return await _context.Reservations
            .Include(r => r.Utilisateur)
            .FirstOrDefaultAsync(r => r.Id == id) 
            .ConfigureAwait(false);*/ // J'ai piqué ca depuis reservation FirstOrDefaultAsync

            return await _context.Utilisateurs
                .FirstOrDefaultAsync(r => r.Id == id)
                .ConfigureAwait(false);
        }      

        /*/// <summary>
        /// Cette méthode permet de recupérer les utilisateurs par nom
        /// </summary>
        /// <param name="nom">le nom.</param>
        /// <returns></returns>
        public async Task<List<Entities.Utilisateur>> GetUtilisateursByNomAsync(string nom)
        {
            return await _context.Utilisateurs
                .Where(r => r.Nom == nom)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Cette méthode permet de recupérer les informations d'un utilisateur par son email pour vérifier qu'un autre email ne existe pas
        /// </summary>
        /// <param name="email">L'email de l'utilisateur</param>
        /// <returns></returns>
        public async Task<Entities.Utilisateur> GetUtilisateurByEmailAsync(string email)
        {
            return await _context.Utilisateurs
                .FirstOrDefaultAsync(r => r.Email == email)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Cette méthode permet de recupérer les utilisateurs par leur date de naissance
        /// </summary>
        /// <param name="dateNaissance">la date de naissance.</param>
        /// <returns></returns>
        public async Task<List<Entities.Utilisateur>> GetUtilisateursByDateNaissanceAsync(string dateNaissance)
        {
            return await _context.Utilisateurs
                .Where(r => r.DateNaissance == dateNaissance)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Cette methode permet de créer un nouvel utilisateur.
        /// </summary>
        /// <param name="utilisateur">Les informations d'un nouvel utilisateur</param>
        /// <returns></returns>
        public async Task<Entities.Utilisateur> CreateUtilisateurAsync(Entities.Utilisateur utilisateur)
        {
           await _context.Utilisateurs.AddAsync(utilisateur);
           await _context.SaveChangesAsync();
            return utilisateur;
        }*/
    }
}
