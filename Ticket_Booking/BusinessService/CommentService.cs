using DataService.Entities;
using DataService.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessService
{
    
    public class CommentService: ICommentService
    {
        private readonly ICommentRepo _commentRepository;
       
       
        public CommentService(ICommentRepo commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public List<Comment> GetComments()
        {
            List<Comment> comments = new List<Comment>();
            comments = _commentRepository.getAllComments();
            return comments.ToList();
        }
        public Comment GetComment(int id)
        {
            Comment comment = _commentRepository.getComment(id);
            return comment;
        }

        public List<Comment> GetCommentByUserId(int id)
        {
            return _commentRepository.getCommentByUserId(id).ToList();
            
        }

        public List<Comment> GetCommentByEventId(int id)
        {
             return _commentRepository.getCommentByEventId(id).ToList();
            
        }

        public bool AddComment(Comment newData)
        {

            return _commentRepository.addComment(newData);
           
            
        }
    }
}
