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
        Comment getCommentByUserId(int id);
        Comment getCommentByEventId(int id);
        bool add(Comment commentEntity);
    }
}
