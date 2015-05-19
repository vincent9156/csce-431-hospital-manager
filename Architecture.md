

# Introduction #

This will outline our architecture for the rest of the assignment. Our project uses MVC (Model-View-Controller) in C# on ASP.NET.


# Architecture #
![http://imgur.com/Ve06W.png](http://imgur.com/Ve06W.png)

## Logic ##

### Controllers ###
Controllers contain the business logic for our program.

An example of something found in a controller would be determining if a user's username is properly formatted (eg. contains no spaces) or checking whether or not a user made a mistake when inputting his credit card number (eg. with the [Luhn Algorithm](http://en.wikipedia.org/wiki/Luhn_algorithm)).

Controllers interact with the database through the [repository](#Repositories.md) layer. Any data that needs to be displayed to the user is added to a [view model](#View_Models.md) and is passed to the [view](#Views.md).

## Data ##

### Models ###
Models are an object representation of an entity in the database.

For instance, if we have a "People" table containing the columns "Name" and "Address", we would also have a model called "Person" containing the attributes "Name" and "Address". It is important to note that models are not always this simple. A model can contain data pulled from multiple tables and relations.

Models' data members are populated by the [repository](#Repositories.md) layer when retrieving data from the database and by the [controller](#Controllers.md) when inserting into the database. Models are a main source of data for the [controller](#Controllers.md).

### View Models ###
View Models are like [models](#Models.md) in that they are an object representing some entity. The difference is that view models may not contain all of the data that a model may contain. To phrase it differently, a view model is often a subset of some model.

View models are necessary to keep data away from the view that does not need to be displayed. For instance if we have a Person object that contains a field "SocialSecurityNumber", we would not want that data accessible to the view. In this case, we can create a PersonViewModel that contains all of the data members of the Person object except for the SocialSecurityNumber data member.

View Models are populated by the [controller](#Controllers.md) before being passed to the [view](#Views.md) to be used.

### Repositories ###
Repositories are a layer of abstraction that sits on top of the database that separates the [controller](#Controllers.md) from having concern itself with how we store the data. A repository contains a link to some data context object and uses [Linq](http://en.wikipedia.org/wiki/Language_Integrated_Query) to pull data from the database.

Repository classes are called on by controllers to pull data from the database and return to them [models](#Models.md) that contain the requested data. Repositories may also have methods that take models and insert them into the database or edit existing values in the database.

## Presentation ##

### Views ###
Views are the entities that contain anything the user sees and interacts with. For instance, this is where all of our HTML will exist. For the view to obtain data the user inputted or from the database, it must receive it from the [controller](#Controllers.md). Most of the time, data from the database is passed to it as a [view model](#View_Models.md) object.

# Summary #
Here is an example of what a page request may look like.

![http://imgur.com/knru6.png](http://imgur.com/knru6.png)

# External Links #
[MVC 2 Basics Introduction](http://channel9.msdn.com/blogs/matthijs/aspnet-mvc-2-basics-introduction-by-scott-hanselman) (Video)

[Getting started with MVC](http://www.asp.net/mvc/tutorials/getting-started-with-mvc-part1) (Reading)