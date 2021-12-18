using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD;
using Entity;

namespace WBL
{
    public interface ICompraService
    {
        Task<DBEntity> Create(CompraEntity entity);
        Task<DBEntity> Delete(CompraEntity entity);
        Task<IEnumerable<CompraEntity>> Get();
        Task<CompraEntity> GetById(CompraEntity entity);
        Task<DBEntity> Update(CompraEntity entity);

        
    }

    public class CompraService : ICompraService
    {
        private readonly IDataAccess sql;

        public CompraService(IDataAccess _sql)
        {
            sql = _sql;
        }

        #region MetodosCrud

        //Metodo Get


        public async Task<IEnumerable<CompraEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<CompraEntity, ClientesEntity, ProductoEntity>("CompraObtener", "IdCompra,ClientesId,ProductoId");

                return await result;
            }
            catch (Exception)
            {

                throw;
            }


        }

      
        //Metodo GetById
        public async Task<CompraEntity> GetById(CompraEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<CompraEntity>("CompraObtener", new
                { entity.IdCompra });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Metodo Create

        public async Task<DBEntity> Create(CompraEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("CompraInsertar", new
                {
                    entity.IdCompra,
                    entity.FechaCompra,
                    entity.Monto,
                    entity.Impuesto,
                    entity.Total,
                    entity.Observaciones,
                    entity.Estado,
                    entity.ClientesId,
                    entity.ProductoId



                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Metodo Update
        public async Task<DBEntity> Update(CompraEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("CompraActualizar", new
                {
                    entity.IdCompra,
                    entity.FechaCompra,
                    entity.Monto,
                    entity.Impuesto,
                    entity.Total,
                    entity.Observaciones,
                    entity.Estado,
                    entity.ClientesId,
                    entity.ProductoId


                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Metodo Delete
        public async Task<DBEntity> Delete(CompraEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("CompraEliminar", new
                {
                    entity.IdCompra,



                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }






        #endregion



    }
}
