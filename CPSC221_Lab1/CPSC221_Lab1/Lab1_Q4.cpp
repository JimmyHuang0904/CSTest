// Towers of Hanoi -------------------------

#include <cstdlib> // for atoi
#include <iostream>
// prototype 
void moveDisks(int n, const char* SOURCE, const char* SPARE, const char* DEST);

int main() {

  int n = 3;
  moveDisks(n, "peg A", "peg B", "peg C");

  system("PAUSE");
  return 0;
}
// put your moveDisks() function here 

void moveDisks(int n, const char* SOURCE, const char* SPARE, const char* DEST){
	if(n == 1)
	{
		std::cout << "Move disk from " << SOURCE << " to " << DEST << std::endl;
		return;
	}
		moveDisks(n-1, SOURCE, DEST, SPARE);
		std::cout << "Move disk from " << SOURCE << " to " << DEST << std::endl;
		moveDisks(n-1, SPARE, SOURCE, DEST);
}