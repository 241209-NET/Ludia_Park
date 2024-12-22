# User Stories


## Vendors

### Create vendor
* I want to be able to create a new vendor.
  * When I'm on the `/vendors` page:
    * I can a register a new vendor.

### Adding food item

* As a vendor, I want to be able to add a new food item to my menu.
  * When I'm on the `/vendors/:vendorId/foods` page:
    * I can add a new food item.
   
### Updating food item

* As a vendor, I want to be able to edit my food items.
  * When I'm on the `/foods/:foodId/edit` page:
    * I can make permanent changes to foods on my menu.

### Deleting food item

* As a vendor, I want to be able to delete my food items.
  * When I'm on the `/foods/:foodId` page:
    * I can permanently delete a food item from my menu.


## Diners

### Create diner + cart
* I want to be able to create a new diner and his/her new cart.
  * When I'm on the `/diners` page:
    * I can a register a new diner and create a new, empty cart at the same time.

### Adding food item to cart
* As a diner, I want to be able to add new food items with its quantity to my cart.
  * When I'm on the `/carts/:cartId/foods` page:
    * I can add a new food item and its quantity to my cart.
    * I provide the `foodId` and `qty` in the request body.

### Updating food item in cart
* As a diner, I want to be able to update the food items and quantities in my cart.
  * When I'm on the `/carts/:cartId/foods/:foodId` page:
    * I can edit the food item and its quantity in my cart.
    * I provide the `foodId` and `qty` in the request body.

### Deleting food item in cart
* As a diner, I want to be able to delete the food items in my cart.
  * When I'm on the `/carts/:cartId/foods/:foodId` page:
    * I can delete the food item from my cart.

### Getting all items in cart
* As a diner, I can get a list of all items in my cart, along with the total.
  * When I'm on the `/carts/:cartId` page:
    * I can get a list of all current food items with their quantities and total price in my cart.


## Getting available food items
* I can get a list of all foods available at Ludi's Food Court.
  * When I'm on the `/foods` page:
    * I can get a list of all foods.


## Getting available vendors
* I can get a list of all vendors available at Ludi's Food Court.
  * When I'm on the `/vendors` page:
    * I can get a list of all vendors.

   


