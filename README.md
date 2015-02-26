# RealNumber
A C# library to extend bigInteger to 'Real numbers' 
I create this library to use big numbers not only integer but also fractional number.

#Instantiation
You can instace a real number with

<code>
var number =  new RealNumber("4");
</code>

or

<code>
var number =  new RealNumber(new BigInteger(3));
</code>

or

<code>
var number =  new RealNumber(3);
</code>

#operator
Now the supported operator are:

<code>
+,-,*,/,^, ==, <=, >=, <,>
</code>

^ only with integer exponent and real base.


#method

There are some methods for adjust division precision (<code>Division(RealNumber a, RealNumber b, int prec);PeriodicDivision(RealNumber a, RealNumber b, int prec)</code> to avoid the repeating sequence of numbers in the result.

The method to calculate nth root is
<code>nRoot(RealNumber num, RealNumber root, RealNumber maxError,int prec = 15)</code>  it support only integer root.
