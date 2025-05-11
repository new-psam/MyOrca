using System.Net.Sockets;
using System.Runtime.InteropServices.JavaScript;

namespace MyOrca.ViewModels;

public class ResultViewModel<T>
{
    public ResultViewModel(T data, List<string> errors)
    {
        Data = data;
        Errors = errors;
    }

    public ResultViewModel(T data) // só em caso de sucesso
    {
        Data = data;
    }

    public ResultViewModel(List<string> errors) // só em caso de erros
    {
        Errors = errors;
    }

    public ResultViewModel(string error)
    {
        Errors.Add(error);
    }
    
    //---------------------------
    public T Data { get; private set; }
    public List<string> Errors { get; private set; } = new(); // nova forma de construtor
}