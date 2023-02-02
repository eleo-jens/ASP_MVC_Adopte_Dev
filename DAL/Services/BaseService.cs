using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    // Classe commune pour la configuration de la Connection String: plus sécuritaire
    // Subit une injection de dépendance de IConfiguration: l'objet de configuration de notre application 
    // qui a accès à app_settings.json où se trouve la connection String
    public abstract class BaseService
    {
        protected readonly string _connectionString; 
        public BaseService (IConfiguration config, string dbName)
        {
            if (config is null) _connectionString = dbName; // A supprimer après - c'est juste pour pouvoir faire le test en console
            else _connectionString = config.GetConnectionString(dbName);
        }
    }
}
