using Microsoft.EntityFrameworkCore;
using NetCoreCache.Domain.Context;
using NetCoreCache.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Linq;
using NetCoreCache.Domain.Interfaces.Repositories;
using System.IO;
using Newtonsoft.Json;

namespace NetCoreCache.Domain.Repositories
{
    public class AreaRepository : RepositoryBase<Area>, IAreaRepository
    {
        public AreaRepository(DBContext context)
            : base(context)
        {
        }
        
        public override IEnumerable<Area> ListarTodos()
        {
            #region Areas recuperadas do Banco
            /*
            var cn = Db.Database.GetDbConnection();
            string sql = @"SELECT  a.id_area as IdArea,a.descricao_area as descricao,a.status,
                            d.id_departamento as IdDepartamento,d.descricao_departamento as descricao,d.status,
                            s.id_setor as IdSetor,s.descricao_setor as descricao,s.status
                            FROM TBL_SICSV_AREA a INNER JOIN 
                            TBL_STAR_Departamento d ON a.id_area = d.id_area INNER JOIN
                            TBL_STAR_Setor s ON d.id_departamento = s.id_departamento";
            var areas = cn.Query<Area, Departamento, Setor, Area>(sql,
                (a, d, s) =>
                {
                    if (d != null)
                    {
                        if (s != null)
                            d.Setores.Add(s);

                        a.Departamentos.Add(d);
                    }
                    return a;
                }
                , splitOn: "idArea,idDepartamento,idSetor")
                .Distinct()
                .ToList();
            */
            #endregion

            #region Areas recuperadas de um arquivo Json
            //Com a finalidade de não precisar configurar o banco e os dados, realizo a busca em um arquivo json para teste
            var diretorio = Directory.GetCurrentDirectory();
            var arquivo = Directory.GetParent(diretorio).FullName;
            arquivo+= "//NetCoreCache.Domain//ArquivoJsonBanco//areas.json";
            using (StreamReader r = new StreamReader(arquivo))
            {
                string json = r.ReadToEnd();
                var areas = JsonConvert.DeserializeObject<List<Area>>(json);
                return areas;
            }
            #endregion
                
        }
    }
}
