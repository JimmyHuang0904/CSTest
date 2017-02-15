#include <iostream>

#define SIZE 10

int ArrGlobal[SIZE];

void fill_array(int, int);

int main(void){

	fill_array(0,5);
	
	for( int i = 0; i < SIZE; i++){
		std::cout << "Array[" << i << "] =" << ArrGlobal[i] << std::endl;
	}
	
	system("PAUSE");
	return 0;
}

void fill_array(int first, int increm){
	for( int i = 0; i < SIZE; i++){
		ArrGlobal[i] = first + increm * i;
	}
}