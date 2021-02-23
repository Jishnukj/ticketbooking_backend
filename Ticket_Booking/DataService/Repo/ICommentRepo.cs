using DataService.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Repo
{
    public interface ICommentRepo
    {
        List<Comment> getAllComments();
        Comment getComment(int id);
        List<Comment> getCommentByUserId(int id);
        List<Comment> getCommentByEventId(int id);
        bool addComment(Comment commentEntity);
    }
}
