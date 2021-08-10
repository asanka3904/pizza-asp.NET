using System.Collections.Generic;
using System.Linq;
using tute.Models;

namespace tute.Services
{

    public static class PizzaService{
   public static List<Pizza> Pizzas { get; private set; }
   public static int nextid=3;

  

  static PizzaService(){
      Pizzas=new List<Pizza>(){
          new Pizza{Id = 1, Name = "Classic Italian", IsGlutenFree = false},
          new Pizza{Id=2, Name = "Chicken brazz", IsGlutenFree=true}
      };
  }

        public static List<Pizza> GetAll()=> Pizzas;

        public static Pizza GetPizza(int id)=> Pizzas.FirstOrDefault(p=>p.Id == id);


        public static void AddPizza(Pizza pizza){
             pizza.Id=nextid++;
             Pizzas.Add(pizza);
        }


        public static void RemovePizza(int id){
            var pizza=GetPizza(id);
            if(pizza is null) return;
            Pizzas.Remove(pizza);
        }

        public static void UpdatePizza(Pizza pizza){
            var index=Pizzas.FindIndex(p=>p.Id == pizza.Id);
            if(index==-1) return;
            Pizzas[index]=pizza;
        }


    }
}