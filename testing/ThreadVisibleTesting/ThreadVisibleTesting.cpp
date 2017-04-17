// ThreadVisibleTesting.cpp : Defines the entry point for the console application.
//
#include "stdafx.h"
#include <process.h>
#include <Windows.h>

/*
Hi Eric,

I has approved this code review. But after some thinking this noon, 
I think that you need pay more attention HasBeenUpdated(), which will 
access the member m_bHasBeenUpdated but not using any thread sync mechanism. 
Please considering is it thread-safe?

I also write a test program to verify whether the BOOL(typedef int BOOL) is visibility in multiple threads in Windows. 
Visibility means that one thread modify someone shared variable, then other threads can see the modification right now. 
The result is that BOOL is un-visible.  So, although you change the m_bHasBeenUpdated = FALSE, it is very possible that 
other threads cannot see this change right now in some condition.

The sample code is very easy. If the result of ++nRace++ can be reflected to other threads, then the expected result nRace == 20000. 
But the actual result nRace is not equal 20000.

*/

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

