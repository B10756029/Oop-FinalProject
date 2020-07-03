#include <iostream>
#include <cstdlib>
#include <ctime>

using namespace std;

int main()
{
	srand(time(NULL));
	int a[4], r, f, n, c, x;
	for ( int i = 0 ; i < 4 ; i++ )
	{
		a[i] = 0;
	}
	
	for ( int i = 0 ; i < 4 ; i++ )
	{
		if ( i == 0 )
		{
			a[i] = rand()%10;
		}
		else
		{
			int n;
			do
			{
				n = 0;
				a[i] = rand() % 10;
				for( int j = 0 ; j < i ; j++ )
				{
					if( a[i] == a[j] )
					{
						n++;
					}
				}	
			}while( n!=0 );
		
		}
	}
	for ( int i = 0 ; i < 4 ; i++ )
	{
		cout << a[i];
	}
	cout << endl;
	while(1)
	{
		cout << "Please enter your number:";
		cin >> n;
		c++;
		r = 0;
		f = 0;
		for( int i = 3 ; i >= 0 ; i-- )
		{
			x = n % 10;
			
			for ( int j = 3 ; j >= 0  ; j-- )
			{
				if( x == a[i] )
				{
					r++;
					break;
				}
				else
				{
					if( x == a[j] )
					{
						f++;
						break;
					} 
				}
			}
			n /= 10;
		}
		if( r == 4 )
		{
			cout << "Bingo! " << "the total of " << c << " times.";
			break;
		}
		else
		{
			cout << r << "A" << f << "B" << endl;
		}
	}
	
	
}
