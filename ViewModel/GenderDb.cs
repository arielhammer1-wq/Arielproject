using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class GenderDB : BaseDB
    {
        public GenderList SelectAll()
        {
            command.CommandText = "SELECT * FROM Gender";
            GenderList list = new GenderList(base.Select());
            return list;
        }
        public static Gender SelectById(int id)
        {
            GenderDB db = new GenderDB();
            GenderList list = db.SelectAll();
            Gender g = list.Find(item => item.Id == id);
            return g;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Gender g = entity as Gender;
            g.Id = Convert.ToInt32(reader["genderid"]);
            g.GenderName = reader["GenderName"].ToString();
            base.CreateModel(entity);
            return entity;
        }

        protected override BaseEntity NewEntity()
        {
            return new Gender();
        }
    }
}
