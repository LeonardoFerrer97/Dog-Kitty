using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IChatRepository
    {
        List<Chat> GetChats(string title);

    }
}
