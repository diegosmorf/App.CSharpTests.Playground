# App.CSharpTests.Playground

Make an attempt at each of these questions. Given the time constraints, feel free to skip
some of the sub-questions.
1.Word Count
Consider a text document (e.g. stuff.txt) that contains N lines of text.
a. Write an algorithm that returns the word counts for each unique word found in
the document. Explain why you chose your algorithm (e.g. speed-memory trade
off, distribution of computation, etc.), and perhaps propose alternative strategies
(but don’t code them up).
b. How might you handle misspelled words?
2. Intersection Algorithm
Write an algorithm to solve the following:
Given two linked lists, return the intersection of the two lists: i.e. return a list containing only
the elements that occur in both of the input lists (recall our guidelines for solving algorithmic
problems).
3. The Barber Shop
There is a Barber shop with a barber and n chairs.
When there are no customers the barber keeps sleeping on a chair.
As soon as a customer arrives, he wakes the barber up if sleeping.
If there are no other waiting customers, the barber serves him right away.
Otherwise, the customer can sit and wait as long as there are available chairs in the waiting
room.
When all chairs are occupied the customer has to look for another barber shop.
a. Write the source code to manage the barber and his customers, in order to handle
potential race conditions (i.e., competing customers).
b. Explain how deadlock, livelock and starvation are guaranteed.
c. Compare your solutions with other synchronization mechanisms you know, highlight
pros and cons in terms of tim
