using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedCSharp {

    public class Iterators : ITutorial {

        public void Run() {
            var dal = new DAL();
            
            foreach (var entity in dal.Entities<Company>()) {
                Console.WriteLine("Read Company with id: " + entity.Id);
            }
        }

        public interface IEntity {
            int Id { get; set; }
        }

        public class DAL {

            public IEnumerable<TEntity> Entities<TEntity>() where TEntity : class, IEntity, new() {
                var count = new Random().Next(10);
                for (var i = 0; i < count; i++) {
                    var entity = new TEntity { Id = i };
                    yield return entity;
                }
            }
        }

        public class Company : IEntity {
            public int Id { get; set; }
        }
    }
}