#ifndef _MathFunctions_h
#define _MathFunctions_h
#include <iostream> 

#define HAVE_LOG
#define HAVE_EXP

double mysqrt(double x);

double mysqrt(double x)
{
	double result = x; 
	if(x <0 ) return 0;
	// if we have both log and exp then use them
#if defined (HAVE_LOG) && defined (HAVE_EXP)
  result = exp(log(x)*0.5);
#else // otherwise use an iterative approach
  for(int i=0; i < 1000000 && result*result > x; i++)
  {
  	result-=1;
  	std::cout << "Approximation: " << result << std::endl;
  }
#endif
  return result;
}


#endif
