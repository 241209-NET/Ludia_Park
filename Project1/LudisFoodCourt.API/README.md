<br />

# <div align="center">🍕Welcome to <ins>Ludi's Food Court</ins>!!🍔<div>
Ludi's Food Court is a place where diners can come, order foods from different vendors, and have their total calculated in their cart!
Come on in and enjoy the tasty foods we have to offer!!  ❤️

<br />


![image](https://github.com/user-attachments/assets/fe425760-9347-406c-963a-cd553b352adc)

<div align="right">by: Ludia Park</div> 

<br />

***
 <br />

## Database Schema

![image](https://github.com/user-attachments/assets/221ca8ad-13ac-43d5-95cd-84189013d6b0)



<br />

***

<br />

## User Stories

<strong>Peruse through the food court and see all vendors</strong> 🏪
* I can get a list of all vendors available at Ludi's Food Court.
  * When I'm on the `/vendors` page:
    * I can get a list of all vendors.


<strong>View menu of vendor by vendor id</strong> 🍜
* I can get a list of all foods available at each vendor.
  * When I'm on the `/vendors/:vendorId/foods` page:
    * I can get a list of all foods at this vendor by its id.

#

### Vendors: 👨‍🍳

<strong>Create vendor</strong> 
* I want to be able to create a new vendor.
  * When I'm on the `/vendors` page:
    * I can a register a new vendor.

<strong>Adding food item</strong>
* As a vendor, I want to be able to add a new food item to my menu.
  * When I'm on the `/vendors/:vendorId/foods` page:
    * I can add a new food item.
   
<strong>Updating food item</strong>
* As a vendor, I want to be able to edit my food items.
  * When I'm on the `/foods/:foodId/edit` page:
    * I can make permanent changes to foods on my menu.

<strong>Deleting food item</strong>
* As a vendor, I want to be able to delete my food items.
  * When I'm on the `/foods/:foodId` page:
    * I can permanently delete a food item from my menu.
      
#

### Diners: 🫃

<strong>Create diner + cart</strong>
* I want to be able to create a new diner and his/her new cart.
  * When I'm on the `/diners` page:
    * I can a register a new diner and create a new, empty cart at the same time.

<strong>Adding food item to cart</strong>
* As a diner, I want to be able to add new food items with its quantity to my cart.
  * When I'm on the `/carts/:cartId/foods` page:
    * I can add a new food item and its quantity to my cart.
    * I provide the `foodId` and `qty` in the request body.

<strong>Updating food item in cart</strong>
* As a diner, I want to be able to update the food items and quantities in my cart.
  * When I'm on the `/carts/:cartId/foods/:foodId` page:
    * I can edit the food item and its quantity in my cart.
    * I provide the `foodId` and `qty` in the request body.

<strong>Deleting food item in cart</strong>
* As a diner, I want to be able to delete the food items in my cart.
  * When I'm on the `/carts/:cartId/foods/:foodId` page:
    * I can delete the food item from my cart.

<strong>Getting all items in cart</strong>
* As a diner, I can get a list of all items in my cart, along with the total.
  * When I'm on the `/carts/:cartId` page:
    * I can get a list of all current food items with their quantities and total price in my cart. 

<br />

***

<br />

## Project Requirements
* ASP.NET Core application
* Should build and run
* Unit Testing (20% code coverage for Services layer)
* Should be RESTful API

<br />

***

<br />

## Tech Stack
* C# (Back End Programming Language)
* SQL Server (local DB)
* EF Core (ORM Tech)
* ASP.NET (Web API Framework)

<br />

***

<br />

## MVP Feature List
* Upon diner creation, cart gets created.
* Diners can add to, update, or delete items in their cart.
* Cart will have all items added and the total price.
* Vendors can be created.
* Vendors can add, update, or delete food items from their menus.
* Menus can be viewed by vendor.
* A list of all vendors can be viewed.

<br />

***

<br />

## Stretch Goals
* Implement login sessions for diners.
* Diners can return to the food court with their logins and start a new cart.


<br />


   


