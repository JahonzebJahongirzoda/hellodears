namespace Infrastructure.Services;
using System.Net;
using Dapper;
using Domain.Entities;
using Npgsql;
using Infrastructure.DataContext;


public class TodoServices
{
    private DataContext _context;

    public TodoServices(DataContext context)
    {
        _context = context;
    }



    public async Task<string> Getallfromtodo()
    {
        using (var connection = _context.CreateConnection())

        {
            try
            {
                var sql = "Select * from todo";
                var res = await connection.QueryAsync<TodoServices>(sql);

                return new string("Success");
            }
            catch (System.Exception)
            {
            }
            return new string("Error");

        }
    }

    public async Task<string> AddTodo(Todo todo)
    {

        using (var connection = _context.CreateConnection())
        {
            try
            {
                string sql = $"INSERT INTO todo (TaskName) VALUES ({todo.TaskName})";
                var response = await connection.ExecuteAsync(sql);
                return new string("Success");
            }
            catch (System.Exception)
            {
                return new string("Error");
            }

        }

    }





    public async Task<string> UpdateTodo(Todo todo)
    {

        using (var connection = _context.CreateConnection())
        {
            try
            {
                string sql = $"UPDATE set  TaskName = '{todo.TaskName}' WHERE id = '{todo.Id}'; ";
                var response = await connection.ExecuteAsync(sql);
                return new string("Success");
            }
            catch (System.Exception)
            {
                return new string("Error");

            }


        }

    }



    public async Task<string> DeleteTodo(int id)
    {

        using (var connection = _context.CreateConnection())


            try
            {
                string sql = $"delete from todo where id ={id}";
                var response = await connection.ExecuteAsync(sql);
                return new string("Success");
            }
            catch (System.Exception)
            {

                return new string("Error");
            }



    }



}

