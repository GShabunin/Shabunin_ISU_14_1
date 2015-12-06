using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroEditor.Model.Items;
using HeroEditor.Service.DataBases;

namespace HeroEditor.Model.Factories
{
    class ChestFactory : IITemsFactory
    {
        private IConnectionBd _connection;

        public ChestFactory(IConnectionBd connection)
        {
            if (connection == null) throw new ArgumentNullException("connection");

            _connection = connection;
        }

        public IList<ItemModel> Items
        {
            get
            {
                List<ItemModel> listChests = new List<ItemModel>();

                foreach(var z in _connection.Items)
                {
                    if (z is ChestModel)
                        listChests.Add(z as ChestModel);
                }

                return listChests;
            }
        }
    }
}
