using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingTrackerV2.Model.SportActivities;
using TrainingTrackerV2.Model.SportActivities.Implementations;

namespace TrainingTrackerV2.DataBase
{
    interface IConnectionDb
    {
        /// <summary>
        /// Поле для того , чтобы получить список тренировок из базы данных (пентагона, например)
        /// Но если ты кулхацкер и думаешь, что получил ссылку на лист и теперь можешь работать
        /// с ними через ссылку, то подумай 10 раз, потому что интерфейс проектируется таким образом,
        /// что данное свойство только для чтения. для изменения используй набор соответствующих
        /// методов. Если ты меня не послушал - твои проблемы, я все равно уже жру Оливьешку
        /// на новый год и точно ничего не буду править в твоих ошибках.
        /// 
        /// С новым годом, Данияр Олегович!
        /// </summary>
        IList<ITraining> Trainings { get; }
        IList<IExercise> Exercises { get; }

        bool AddNewTraining(ITraining training);
        bool RemoveTraining(ITraining training);
        bool UpdateTraining(ITraining training);
    }
}
