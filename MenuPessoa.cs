namespace programPeople;
using System.IO.Compression;

//Crianção to tratamento de exceção personalizado
class PessoaException : ApplicationException{
    public string correctionSuggestion {get;set;}

    public PessoaException(string suggestion){
        this.correctionSuggestion = suggestion;
    }
}

//Criação Classe Pessoa
class MenuPessoa
{
    private string _name;
    private string _CPF;
    private  int _age;
    

    //Métodos de acesso (getters/setter).
    public string Name
    {
        get {return this._name;}
        set {this._name = value;}
    }
    public string CPF
    {
        get {return this._CPF;}
        set {
            if (value == null || value == "")
                throw new PessoaException("Nenhum CPF digitado");
                this._CPF = value;
            }
    }
    public int Age
    {
        get {return this._age;}
        set {
            if (value < 0 || value > 150)
            throw new PessoaException("Idade Inválida");
            this._age = value;}
            
    }

    //Construtor
    public MenuPessoa(string _CPF, string _name, int _age)
    {        
        this.CPF =  _CPF;
        this.Name = _name;        
        this.Age = _age;
    }

    //Criação Lista
    private List<MenuPessoa> listPeople;
     
    //Método Cadastrar Pessoa

    public void CadastrarPessoa()
    {
        Console.WriteLine("Seja bem-vindx a opção 'Cadastrar Pessoa'!");
        Console.WriteLine("Por gentileza, digite seu CPF:");
        string CPF = Convert.ToString(Console.ReadLine());
        Console.WriteLine("Agora, digite seu nome completo: ");
        string Name = Convert.ToString(Console.ReadLine());
        Console.WriteLine("E por fim, digite sua idade: ");
        int Age = Convert.ToInt32(Console.ReadLine());

        MenuPessoa people = new MenuPessoa(CPF, Name, Age);
        listPeople.Add(people);
    }

    //Método Remover Pessoa
    public void RemoverPessoa()
    {
        Console.WriteLine("Por gentileza, digite o CPF que você deseja remover o cadastro: ");
        string CPF = Console.ReadLine();
        foreach(MenuPessoa p in listPeople)
        {
            if(p.CPF == CPF)
            {
                listPeople.Remove(p);
                return;
            }
        }
    }

    //Método Imprimir 
    public void Imprimir()
    {
        foreach(MenuPessoa p in listPeople)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Nome: " + p.Name);
            Console.WriteLine("CPF: " + p.CPF);
            Console.WriteLine("Idade:" + p.Age);
            Console.WriteLine("--------------------------------");      
        }
    }
    
    //Método Menu
    public void Menu()
    { 
        listPeople = new List<MenuPessoa>();

        bool loop = true;
        while (loop)
        {
            try
            {
                Console.WriteLine("Por gentileza, digite o número da sua opção: ");
                Console.WriteLine("1 - Cadastrar pessoa;");
                Console.WriteLine("2 - Remover pessoa;");
                Console.WriteLine("3 - Imprimir lista de pessoas.");
                Console.WriteLine("0 - Sair");

                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                   CadastrarPessoa();     
                }
                else if (choice == 2)
                {
                    RemoverPessoa();
                }
                else if(choice == 3)
                {
                    Imprimir();
                }
                else if(choice == 0)
                {
                    loop = false;
                }
                else
                {
                    Console.WriteLine("Escolha inválida!");
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine("O dado inserido não é compatível com o campo, tente novamente!");
                Console.WriteLine(e.Message);
            }
            catch (PessoaException e)
            {
                Console.WriteLine(e.correctionSuggestion);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

