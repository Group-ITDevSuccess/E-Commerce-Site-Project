﻿using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.SqlCommand;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Entity.Mapping;

namespace WebApplication.Entity
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory = null;

        public static ISessionFactory GetSessionFactory()
        {
            try
            {
                if (_sessionFactory == null)
                {
                    var cfg = MySQLConfiguration.Standard
                        .ConnectionString(c => c.Is(
     "Server=localhost; Port=3306; Database=e_commerce_site_project; Uid=root; Pwd=AllahSeul;default command timeout=20000"));
                    _sessionFactory = Fluently.Configure()
                        .Database(cfg).Mappings(
                        m => m.FluentMappings.AddFromAssemblyOf<Users>()
                )
                        .ExposeConfiguration(_buildSchema)
                        .ExposeConfiguration(x =>
                        {
                            x.SetInterceptor(new HelperSqlStatementInterceptor());
                        })
                        .BuildSessionFactory();
                }
                return _sessionFactory;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static void _buildSchema(NHibernate.Cfg.Configuration config)
        {
            new SchemaUpdate(config).Execute(true, true);
        }

        public class HelperSqlStatementInterceptor: EmptyInterceptor
        {
            public override SqlString OnPrepareStatement(NHibernate.SqlCommand.SqlString sql)
            {
                Trace.WriteLine(sql.ToString());
                return sql;
            }
        }
    }
}
