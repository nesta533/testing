// ThreadVisibleTesting.cpp : Defines the entry point for the console application.
//
#include "stdafx.h"
#include <process.h>
#include <Windows.h>

const int THREAD_COUNT = 20;
int nRace = 0;
void Increase()
{
	++nRace;
}

unsigned int __stdcall SecondaryThreadFunc(void* pArguments) {
	for (int i = 0; i < 1000; i++)
	{
		Increase();
	}
	return 0;
}



int main()
{
	HANDLE hThreads[THREAD_COUNT];

	for (int i = 0; i < THREAD_COUNT; i++)
	{
		unsigned int nThreadId = 0;
		hThreads[i] = (HANDLE)::_beginthreadex(NULL, 0, &SecondaryThreadFunc, NULL, 0, &nThreadId);

	}

	::WaitForMultipleObjects(THREAD_COUNT, hThreads, TRUE, -1);
	printf("counter should be 20000; it is -> %d\n", nRace);
	return 0;
}

