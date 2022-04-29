using System.Security.Cryptography;
using System.Text;
using Esercizio.Repositories;

namespace Esercizio.Service;

public class OperatoreService
{

    private OperatoreRepository operatoreRepository = new OperatoreRepository();

    public IEnumerable<Operatore> GetOperatori()
    {
        return operatoreRepository.GetOperatori();
    }

    public Operatore GetOperatore(int id)
    {
        return operatoreRepository.GetOperatore(id);
    }

    public bool Create(Operatore operatore)
    {
        if (operatoreRepository.GetOperatore(operatore.Id) == null)
        {
            if ((String.IsNullOrEmpty(operatore.Nome)) && (operatore.Nome.Length < 0))
            {
                return false;
            } 
            else if ((String.IsNullOrEmpty(operatore.Password)) && (operatore.Password.Length < 0))
            {
                return false;
            }
            else
            {
                var text = operatore.Password;
                var byteArray = ASCIIEncoding.ASCII.GetBytes(text);
                byte[] mySHA256 = SHA256.Create().ComputeHash(byteArray);
                var password = Convert.ToBase64String(mySHA256);
                return operatoreRepository.Create(operatore);
            }
            }
            else
            {
                return false;
            }

    }

    public bool Update(Operatore operatore)
    {
        return operatoreRepository.Update(operatore);
    }

    public bool Delete(int id)
    {
        return operatoreRepository.Delete(id);
    }

}