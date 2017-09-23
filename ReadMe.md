## Table of contents
1. [Overview](#overview)
	1. [Prerequisites](#prerequisites)
	1. [Our Values](#our-values)
1. [Exercise](#exercise)
	1. [About the provided program](#about-the-provided-program)
	1. [What we are looking for](#what-we-are-looking-for)
	1. [Submitting the exercise](#submitting-the-exercise)
1. [How to](#how-to)
	1. [Create a local clone of the Git repository](#create-a-local-clone-of-the-git-repository)
	1. [Commit your code](#commit-your-code)

# Overview
Thank you for participating in our exercise. For further information, please check the information below:
- We invite you to read the [Allegis Group Terms of Service](License.md) before you start the test.
- If you encounter any major issues during the process and require further assistance, please send us an email at appsdevinterviewprocess@teksystems.com. We will get back to you within 48 hours (Monday to Friday).

Remember, do not hesitate to contact your recruiter for further assistance.

## Prerequisites
- [Visual Studio 2015 Community Edition (update 3)](https://www.visualstudio.com/en-us/products/visual-studio-community-vs.aspx), or latest, with at least [.NET Framework 4.6](https://www.microsoft.com/en-us/download/details.aspx?id=48130).

## Our Values
What makes our team unique and great at TEKSystems is our focus on code quality. We pride ourselves in having a great team with strong engineering practices skills. 

This is why customers choose us as their partner. They don’t want us to just develop some code for them, they want us to build an enterprise quality solution that will support the growth of their business. This is why we believe that you have to start with a great foundation that is based on strong engineering practices, code quality and object oriented design.
As you know the best way to judge an artist/a developer is to see their art/their code. We know that a written or an online technical test is not the right way to evaluate a good developer so we want to give you the opportunity to show us what you can do and who you are as a developer at your own time. This is why we would like to give you a small challenge so we can see how you think about object oriented design and code quality. We know you are probably very busy and we appreciate the time you will be investing on this but we believe this is the best way for us to get to know the great developer you are.

We are very excited to see what you will come up with.

**Sam Malek**

Practice Director - Application Development and Management

# Exercise
The goal of this exercise is to review a provided program, and propose various solutions to improve the existing code considering criteria explained below.

Estimated exercise length: a minimum of 2h.

## About the provided program
The provided program calculates tax and totals for shopping carts. It runs correctly, provides output demonstrating the business rules explained below, and include automated tests which provide a code coverage of ~90% (class `Program` excluded).

This program will be maintained for at least 10 years, possibly up to 15. It is expected that changes over time will include both the modification of existing tax rates and the addition of new tax rules.

### Business rules
1. When I purchase items, I receive a receipt which lists the names of all the products and their prices (including tax). It also includes the total price of the products and the total amount of sales taxes paid.
1. Basic sales tax is applicable at a rate of 10% on all goods **except**:
	* Food
	* Book
	* Medical
1. Import tax is applicable at a rate of 5% on all imported goods, with no exemptions.
1. Tax should be rounded up to the nearest five cents for each product of the cart.

## What we are looking for
The current code is difficult to read and so to maintain. Furthermore evolutivity is questionable. We need solutions to improve this code.

Amongst other things, we are interested in evaluating:
* Design: 
	* Object-oriented: respect of OOP and SOLID principles.
	* Pattern: correct use and implementation of design patterns.
* Code quality: consistency and proficiency in coding style.
	* Readability: code easy to read and understand.  
	* Maintainability: code easy to maintain and to add new features.
* Automated tests:
	* Tests design: tests are well designed, and require minimal changes when code is changed.
	* Coverage: tests cover all the functionalities.
	* Object Mocking: mocking and/or fake are used efficiently.  
* Solution structure: correct use of namespaces / packages.

According to the criteria specified above, refactor directly the code. Anything, including automated tests, can be changed. You can completely rewrite the code if you like.

Your solution will be reviewed by a senior software developer.

Keep in mind we are looking to understand how you perceive and approach code quality. As the code is intentionally flawed in various ways and given the limited amount of time, we do not expect your response to address all the problems or expect you to produce a comprehensive listing of all of them.
So we encourage you to focus on areas which seem most critical to you, and you have a well-developed opinion as oppose covering aspects you might be less comfortable with.

## Submitting the exercise
If you would like to leave us feedback on the code exercise and your experiences, please do so by writing your comments to a new file: **FeedBack.md**. Add it to your repository, via text editor, or the GitLab interface.
Any feedback will be greatly appreciated.

In order to finalize the submission process, you will need to push your changes to the remote server. If you're not familiar with Git, please look at [How to commit your code](#Commit-your-code).

Finally, please email your recruiter and [AppsDevInterviewProcess@teksystems.com](mailto:AppsDevInterviewProcess@teksystems.com?cc=<insert-recruiter-email-address-here>&subject=GitLab%20Coding%20Exercise%20Completion%20Notice&body=Hello,%0A%0AI%20have%20completed%20and%20pushed%20the%20assigned%20coding%20exercise%20on%20GitLab.%0A%0AI%20confirm%20that%20above%20pushed%20code%20summary%20is%20accurate.%20Please%20evaluate%20my%20final%20version%20of%20coding%20exercise.%0A%0ARegards, "AppsDevInterviewProcess@teksystems.com") and attach your pushed code summary of your coding exercise.

*Note:
Once your recruiter receives notification that you have completed the exercise, your access to the Git server will be lost, along with your ability to submit any additional changes and feedback.
Please make sure that you are satisfied with the work you have produced.*

**Thank you! We look forward to having an opportunity to meet with you.**

# How to
## Use Git command line
Before running any of those commands, you must:
1. Download & Open your Git tool of choice. You can find a list at [https://git-scm.com/downloads](https://git-scm.com/downloads).
1. Prepare Git to work with our SSL certificates (**VERY IMPORTANT!**):
```
git config --global http.sslVerify false
```

### Create a local clone of the Git repository
Here is what you need to know to successfully clone the repository, and get ready to begin your coding exercise.

1. In order to clone the repository through our firewall, you will need to use HTTPS rather than SSH.
1. Change to the working directory you will do your work from.
1. Clone the repository using the repository URL the GitLab sent to you via e-mail:
```
git clone YOUR_REPOSITORY_URL
```
Note you will be asked to provide your user name and password before working with the remote git server.

### Commit your code
Those commands will add all your changes to your local repository, commit them, then send your changes to the TEKsystems repository:
```
git add --all
git commit -m "A message explaining the changes you're committing, like Exercise completed"
git push
```