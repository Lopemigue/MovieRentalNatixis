# MovieRental Exercise

This is a dummy representation of a movie rental system.
Can you help us fix some issues and implement missing features?

 * The app is throwing an error when we start, please help us. Also, tell us what caused the issue.

   `The issue was caused by registering RentalFeatures as a Singleton, while it depends on MovieRentalDbContext, wich is a Scoped service.`
 * The rental class has a method to save, but it is not async, can you make it async and explain to us what is the difference?

    `The difference is that while async methods don’t block the thread, allowing it to do other work while waiting for the operation to finish (like saving to the database), non-async methods block the thread until the operation is done.
Another difference is in performance — async methods scale better with many concurrent operations (in this case, multiple save operations to the database), while non-async methods can cause slowdowns under load (meaning when the system is busy handling a lot of tasks at the same time).`
 * Please finish the method to filter rentals by customer name, and add the new endpoint.
 * We noticed we do not have a table for customers, it is not good to have just the customer name in the rental.
   Can you help us add a new entity for this? Don't forget to change the customer name field to a foreign key, and fix your previous method!
 * In the MovieFeatures class, there is a method to list all movies, tell us your opinion about it.
 * No exceptions are being caught in this api, how would you deal with these exceptions?


	## Challenge (Nice to have)
We need to implement a new feature in the system that supports automatic payment processing. Given the advancements in technology, it is essential to integrate multiple payment providers into our system.

Here are the specific instructions for this implementation:

* Payment Provider Classes:
    * In the "PaymentProvider" folder, you will find two classes that contain basic (dummy) implementations of payment providers. These can be used as a starting point for your work.
* RentalFeatures Class:
    * Within the RentalFeatures class, you are required to implement the payment processing functionality. This should occur before executing the save command for a rental record.
* Payment Provider Designation:
    * The specific payment provider to be used in a rental is specified in the Rental model under the attribute named "PaymentMethod".
* Extensibility:
    * The system should be designed to allow the addition of more payment providers in the future, ensuring flexibility and scalability.
* Payment Failure Handling:
    * If the payment method fails during the transaction, the system should prevent the creation of the rental record. In such cases, no rental should be saved to the database.
