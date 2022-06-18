using PM02E10056.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PM02E10056.Controls
{
    public class DataBaseSqlite { 

  readonly SQLiteAsyncConnection db;

    //constructor de clase
    public DataBaseSqlite(string pathdb)
    {
        //crear la conexion de la base datos
        db = new SQLiteAsyncConnection(pathdb);
        //creacion de la tabla dentro de sqlite
        db.CreateTableAsync<Localizacion>().Wait();
    }

    //Operaciones CRUD con SQLite
    //READ List Way
    public Task<List<Localizacion>> ObtenerListaUbicacion()
    {
        return db.Table<Localizacion>().ToListAsync();
    }

    //Mostrar solo una ubicacion
    public Task<Localizacion> ObtenerUbicacion(int pcodigo)
    {
        return db.Table<Localizacion>()
            .Where(i => i.codigo == pcodigo)
            .FirstOrDefaultAsync();
    }

    //guardar ubicacion
    public Task<int> GuardarUbicacion(Localizacion ubicacion)
    {
        if (ubicacion.codigo != 0)
        {
            return db.UpdateAsync(ubicacion);
        }
        else
        {
            return db.InsertAsync(ubicacion);
        }



    }
    //Eliminar persona
    public Task<int> EliminarUbicacion(Localizacion ubicacion)
    {
        return db.DeleteAsync(ubicacion);
    }

}
}
