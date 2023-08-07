using School_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_App.Repository
{
public class ClassRepository
    {
        public ClassRepository()
        {
        }

        public void Create(Class Class)
        {
            using (var context = new SchoolDbContext())
            {
                context.Classes.Add(Class);
                context.SaveChanges();
            }
        }

        public Class Read(int ClassId)
        {
            using var context = new SchoolDbContext();
            var existing = context.Classes.Find(ClassId);
            if (existing == null)
            {
                throw new Exception("Class entry not found");
            }

            return existing;
        }

        public void Update(Class Class)
        {
            using (var context = new SchoolDbContext())
            {
                var existing = context.Classes.Find(Class.Id);
                if (existing == null)
                {
                    throw new Exception("Class entry not found");
                }

                existing.Standard = Class.Standard;
                existing.Division = Class.Division;

                context.SaveChanges();
            }
        }

        public void Delete(int ClassId)
        {
            using (var context = new SchoolDbContext())
            {
                var existing = context.Classes.Find(ClassId);
                if (existing == null)
                {
                    throw new Exception("Class entry not found");
                }

                context.Classes.Remove(existing);

                context.SaveChanges();
            }
        }
    }
}
