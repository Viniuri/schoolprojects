// Example program
#include <iostream>
#include <string>
class Time
{
    private:
        int hour;//ore
        int minute;//minuti
        int second;//secondi
   
    public:
         Time(void)          {hour=0;minute=0;second=0;}
    int  getHour(void)       {return hour;}
    int  getMinute(void)     {return minute;}
    int  getSecond(void)     {return second;}
    void setHour(int h)      {hour=h;}
    void setMinute(int m)    {minute=m;}
    void setSecond(int s)    {second=s;}
};
class Date
{
    private:
        int day:
        int month;
        int year;
    public:
             Date(void)       {day=1; month=1;year=2000;}
        int  getDay(void)     {return day;}
        int  getMonth(void)   {return month;}
        int  getYear(void)    {return year;}
        void setDay(int d)    {day=d;}
        void setMonth(int m)  {month=m;}
        void setYear(int y)   {year=y;}
};
class Message
{
    private:
        Date date;
        Time time;
        bool received;
        char message[1024]
       
    public:
            Message(void) {strcpy(message,"");
                            received=false;}
           
        Date getDate(void) {return date;}

       
        Time getTime(void)  {return time;}
                             
                             
        bool isReceived(void) {return received;}
        int getText(chat t[]) {
                                strcpy(t, message);
                                return strlen(t);
                              }
       
        void setDate(Date d)  {date=d;}
        void setTime(Time r) {time=t;}
        void setReceived(bool r){received=r;}
        void setText(char t[]){strcpy(message, t);}
       
};