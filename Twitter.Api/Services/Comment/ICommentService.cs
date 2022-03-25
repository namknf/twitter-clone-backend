namespace Twitter_backend.Services.Comment
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Twitter_backend.Models;

    public interface ICommentService
    {
        Task<int> Create(Comment model);

        Task<bool> Delete(Comment model);

        Task<bool> Update(Comment commentToUpdate);

        Comment GetById(int id);

        List<Comment> GetAllUserComments();

        Task<bool> IsUserOwnsComment(int userId, int commentId);
    }
}
