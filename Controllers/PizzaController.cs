using Microsoft.AspNetCore.Mvc;
using tute.Services;
using tute.Models;
using System.Collections.Generic;


// public struct pizzain{
//     public string Name { get; set; }
//     public bool IsGlutenFree{ get;set;}
// }


namespace tute.Controllers{

[ApiController]
[Route("[controller]")]



public class PizzaController : ControllerBase{
    public PizzaController(){}

    // GET all action
    [HttpGet]
    public ActionResult<List<Pizza>> GetAll()=>PizzaService.GetAll();

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id){
        var pizza=PizzaService.GetPizza(id);
        if(pizza==null){
            return NotFound();
        }else{
            return pizza;
        }
        
    }

    // POST action
    [HttpPost]
    public IActionResult PostPizza(Pizza piz ){
 
           
    PizzaService.AddPizza(piz);

     return CreatedAtAction(nameof(PostPizza),new {id= piz.Id},piz);

    }

    // PUT action

    [HttpPut("{id}")]
     public IActionResult Update(int id, Pizza pizza)
     {
         if (id != pizza.Id) return BadRequest();

        var existingPizza = PizzaService.GetPizza(id);
       if(existingPizza is null)  return NotFound();

       PizzaService.UpdatePizza(pizza);           
       
       return NoContent();
     }

    // DELETE action 

    [HttpDelete("{id}")]
    public IActionResult Delete(int id){
        var pizza= PizzaService.GetPizza(id);
        if(pizza is null) return NotFound();
      
      PizzaService.RemovePizza(id);

      return NoContent();
    }
}



}