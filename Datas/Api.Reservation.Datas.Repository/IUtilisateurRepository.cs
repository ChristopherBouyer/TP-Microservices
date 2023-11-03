
namespace Api.Reservation.Datas.Repository
{
    public interface IUtilisateurRepository
    {
        /// <summary>
        /// Cette méthode permet de recupérer la liste des utilisateurs
        /// </summary>
        /// <returns></returns>
        Task<List<Entities.Utilisateur>> GetUtilisateursAsync();

        /// <summary>
        /// Cette methode permet de créer un nouvel utilisateur.
        /// </summary>
        /// <param name="utilisateur">Les informations d'un' nouvel utilisateur</param>
        /// <returns></returns>
        Task<Entities.Utilisateur> CreateUtilisateurAsync(Entities.Utilisateur utilisateur);

        /// <summary>
        /// Cette méthode permet de recupérer les utilisateurs par l'id
        /// </summary>
        /// <param name="id">l'id.</param>
        /// <returns></returns>
        Task<Entities.Utilisateur> GetUtilisateurByIdAsync(int id);

        /*/// <summary>
        /// Cette méthode permet de recupérer les utilisateurs par le nom
        /// </summary>
        /// <param name="nom">le nom.</param>
        /// <returns></returns>
        Task<List<Entities.Utilisateur>> GetUtilisateursByNomAsync(string nom);

        /// <summary>
        /// Cette méthode permet de recupérer les utilisateurs par l'email
        /// </summary>
        /// <param name="email">l'email'.</param>
        /// <returns></returns>
        Task<List<Entities.Utilisateur>> GetUtilisateursByEmailAsync(string email);

        /// <summary>
        /// Cette méthode permet de recupérer les utilisateurs par la date de naissance
        /// </summary>
        /// <param name="dateNaissance">la date de naissance.</param>
        /// <returns></returns>
        Task<List<Entities.Utilisateur>> GetUtilisateursByDateNaissanceAsync(string dateNaissance);

        /// <summary>
        /// Cette methode permet de créer un nouvel utilisateur.
        /// </summary>
        /// <param name="utilisateur">Les informations d'un' nouvel utilisateur</param>
        /// <returns></returns>
        Task<Entities.Utilisateur> CreateUtilisateurAsync(Entities.Utilisateur utilisateur);*/
    }
}
