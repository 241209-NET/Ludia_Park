# User Stories

## Vendors

### Add food item

* As a vendor, I want to be able to add a new food item to my menu.
  * When I'm on the `/foods/:foodId` page:
    * I can add a new food item.
   
### Updating food item

* As a vendor, I want to be able to edit my food items.
  * When I'm on the `/foods/:foodId/edit` page:
    * I can make permanent changes to foods on my menu.

### Deleting food item

* As a vendor, I want to be able to delete my food items.
  * When I'm on the `/vendors/:vendorId` page:
    * I can permanently delete a food item from my menu.


## Recipes

### Create Recipe

* As a logged in user, I want to be able to post new recipe.
  * When I'm on the `recipes/new` page:
    * I can post a new recipe with a photo, food name, description, ingredients, and instructions.

### Viewing Recipes

* As a logged out user, I will only be able to view a landing page with the following:
  * Background image
  * A button to open a modal to log in or sign up
  * Logo on the top of the page

* As a logged in user, I want to view all recipes by all users.
  * When I'm on the `/` page:
    * I can view all recipes.

* As a logged in user, I want to be able to view all recipes I posted.
  * When I'm on the `/recipes/manage` page:
    * I can view all recipes I posted.
    * I can edit all recipes I posted.
    * I can delete all recipes I posted.

* As a logged in user, I want to be able to view a specific recipe's details and its associated comments.
  * When I'm on the `/recipes/:id` page:
    * I can view the content of the recipe, as well as the associated comments.

### Updating Recipes

* As a logged in user, I want to be able to edit my recipes by clicking an Edit button associated with the recipe when I'm on my get all current user's recipes page.
  * When I'm on the `/recipes/recipeId/edit` page:
    * I can click "Edit" to make permanent changes to recipes I have posted.

### Deleting Recipes

* As a logged in user, I want to be able to delete my recipes by clicking a Delete button associated with the photo when I'm on my get all current user's recipes page.
  * When I'm on the `/users/:userId` page:
    * I can click "Delete" to permanently delete a recipe I have posted.

## Comments

### Create A Comment

* As a logged in user, I want to be able to post a new comment.
  * When I'm on the `/recipes/:recipeId` page:
    * I can post a new comment with an optional photo.

### Viewing Comments

* As a logged in user, I want to view all comments on recipes in reverse chronological order.
  * When I'm on the `/recipes/:recipeId` page:
    * I can view all comments.

### Editing Comments

* As a logged in user, I want to be able to edit my comments by clicking an Edit button associated with the comment when I'm on the associated recipe details page.
  * When I'm on the `/recipes/:recipeId` page, and the comment's userId matches my id:
    * I can click "Edit" to permanently update a comment I have posted.

### Deleting Comments

* As a logged in user, I want to be able to delete my comments by clicking a Delete button associated with the comment when I'm on the associated recipe details page.
  * When I'm on the `/recipes/:recipeId` page, and the comment's userId matches my id:
    * I can click "Delete" to permanently delete a comment I have posted.

## Bookmarks

### Bookmark Recipe

* As a logged in user, I want to be able to bookmark a recipe when I'm on the recipe details page.
  * When I'm on the `/recipes/:recipeId` page:
    * I can click the bookmark icon to add the recipe to my bookmarks collection.

### Unbookmark Recipe
* As a logged in user, I want to be able to unbookmark a recipe when I'm on the recipe details page.
  * When I'm on the `/recipes/:recipeId` page:
    * I can click the unbookmark icon to remove the recipe from my bookmarks collection.
  * When I'm on the `/:userId/bookmarks` page:
    * I can click the unbookmark button to remove that recipe from my bookmarks collection.

### View All Bookmarks
* As a logged in user, I want to be able to view all recipes I have bookmarked.
  * When I'm on the `/recipes/:recipeId` page:
    * I can view if the current recipe is bookmarked or unbookmarked by looking at the icon button.
  * When I'm on the `/:userId/bookmarks` page:
    * I can view all my bookmarked recipes.
   


