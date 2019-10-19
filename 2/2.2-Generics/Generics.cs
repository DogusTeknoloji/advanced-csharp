using System;
using System.Collections.Generic;

namespace AdvancedCSharp {

    public class Generics : ITutorial {

        public void Run() {
            var loggerType = typeof(Logger<>);
            try {
                Activator.CreateInstance(loggerType);
            } catch (Exception ex) {
                Console.WriteLine("Open generics cannot be instantiated. " + ex);
            }

            var ctx = new Context();
            // not allowed
            // ctx.Save(new User());
            ctx.Save(new Company { Id = 42 });
        }

        public interface IEntity {
            int Id { get; set; }
        }

        public class User {
            public string Name { get; set; }
        }

        public class Company : IEntity {
            public int Id { get; set; }
        }

        public class Context {
            Dictionary<Type, Dictionary<int, IEntity>> _entitySet = new Dictionary<Type, Dictionary<int, IEntity>>();

            public int Save<TEntity>(TEntity entity) where TEntity : IEntity {
                var type = typeof(TEntity);

                Dictionary<int, IEntity> typeSet;
                if (!_entitySet.TryGetValue(type, out typeSet)) {
                    typeSet = new Dictionary<int, IEntity>();
                    _entitySet.Add(type, typeSet);
                }
                
                typeSet[entity.Id] = entity;

                var logger = new Logger<TEntity>();
                logger.Log(entity);

                return 1;
            }
        }

        public class Logger<TEntity> where TEntity : IEntity {

            public void Log(TEntity entity) {
                var type = typeof(TEntity);
                Console.WriteLine("Saving " + type + " with Id: " + entity.Id);
            }
        }
    }
}