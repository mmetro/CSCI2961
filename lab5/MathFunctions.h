#ifndef _MathFunctions_h
#define _MathFunctions_h

double mysqrt(double x);

double mysqrt(double x)
{
	double result;
	if(x <0 ) return 0;
	// if we have both log and exp then use them
#if defined (HAVE_LOG) && defined (HAVE_EXP)
  result = exp(log(x)*0.5);
#else // otherwise use an iterative approach
  //return 69;
  result = exp(log(x)*0.5);
#endif
  return result;
}


#endif
