using DataService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataService.Repo
{
    public class CommentRepo : ICommentRepo
    {
        private readonly ApplicationdbContext _dbContext;
        public CommentRepo(ApplicationdbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool addComment(Comment commentEntity)
        {
            _dbContext.Comments.Add(commentEntity);
            _dbContext.SaveChanges();
            return true;
        }

        public Comment getComment(int id)
        {
            Comment comment = _dbContext.Comments.Where(e => e.comment_id == id).FirstOrDefault();
            return comment;
        }

        public List<Comment> getCommentByUserId(int id)
        {
            return _dbContext.Comments.Where(e => e.user_id == id).ToList();
           
        }
        public List<Comment> getCommentByEventId(int id)
        {
            return _dbContext.Comments.Where(e => e.event_id == id).ToList();
             
        }

        public List<Comment> getAllComments()
        {
            return _dbContext.Comments.ToList();
        }

        public bool addReply(int id, string reply)
        {
            Comment comment = _dbContext.Comments.Where(x => x.comment_id == id).FirstOrDefault();
            if(comment!=null)
            {
                comment.reply = reply;
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
