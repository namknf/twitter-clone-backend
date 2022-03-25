namespace Twitter_backend.Services.Comment
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Twitter_backend.Models;
    using Twitter_backend.Repositories;

    public class CommentService : ICommentService
    {
        private readonly IItemsRepository<Comment> _repository;

        public CommentService(IItemsRepository<Comment> repository)
        {
            _repository = repository;
        }

        public async Task<int> Create(Comment model)
        {
            var newItem = await _repository.Add(model);

            return newItem;
        }

        public async Task<bool> Delete(Comment model)
        {
            var affected = await _repository.Remove(model);

            return affected > 0;
        }

        public List<Comment> GetAllUserComments()
        {
            return _repository.GetAll();
        }

        public Comment GetById(int id)
        {
            return _repository.GetById(id);
        }

        public Task<bool> IsUserOwnsComment(int userId, int commentId)
        {
            var comment = _repository.GetById(commentId);

            return Task.FromResult(comment.UserId == userId);
        }

        public async Task<bool> Update(Comment commentToUpdate)
        {
            int affected = await _repository.Update(commentToUpdate);

            return affected > 0;
        }
    }
}
