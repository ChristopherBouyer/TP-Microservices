using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Reservation.Business.Service
{
    public interface IUtilisateurService
    {
        /// <summary>
        /// Cette méthode permet de recupérer la liste des utilisateurs
        /// </summary>
        /// <returns></returns>
        Task<List<Datas.Entities.Utilisateur>> GetUtilisateursAsync();

        /// <summary>
        /// Creates the utilisateur asynchronous.
        /// </summary>
        /// <param name="utilisateur">The utilisateur.</param>
        /// <returns></returns>
        /// <exception cref="Api.Utilisateur.Generals.Common.BusinessException">Echec de création d'un utilisateur : Le siège n'est pas disponible.</exception>
        Task<Datas.Entities.Utilisateur> CreateUtilisateurAsync(Datas.Entities.Utilisateur utilisateur);

        /// <summary>
        /// Cette méthode permet de recupérer un utilisateur
        /// </summary>
        /// <returns></returns>
        Task<Datas.Entities.Utilisateur> GetUtilisateurByIdAsync(int id);

        /// <summary>
        /// Cette méthode permet de mettre à jour un utilisateur
        /// </summary>
        /// <returns></returns>
        Task<Datas.Entities.Utilisateur> UpdateUtilisateurAsync(int id, Utilisateur utilisateur);

        /// <summary>
        /// Cette méthode permet de supprimer un utilisateur
        /// </summary>
        /// <returns></returns>
        Task DeleteUtilisateurAsync(int id);
    }
}
