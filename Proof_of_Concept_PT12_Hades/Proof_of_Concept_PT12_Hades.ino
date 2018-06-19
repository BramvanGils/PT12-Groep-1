#include <Servo.h>
#define 1 // Y positie
#define 2 // Y positie
#define 3 // Y positie
#define 4 // Y positie
#define 5 // Y positie
#define 6 // Y positie
#define 7 // Y positie
#define 8 // Y positie

#define A // X positie
#define B // X positie
#define C // X positie
#define D // X positie
#define E // X positie
#define F // X positie
#define G // X positie
#define H // X positie

#define Down 180 // Z Positie
#define Up 0 // Z Positie


Servo X;
Servo Y;
Servo Z;


void setup() {
  X.attach(PIN);
  Y.attach(PIN);
  Z.attach(PIN);
Serial.begin(115200);
}
int aantal=0;
char data[50];
void loop() {
// Voorbeeld commando parameter vanuit Visual Studio:
// Z-18-AH-Offset||18-AH-Offset
// Als Z wordt doorgegeven, betekent dat dat de arm het schaakstuk eerst moet pakken, bij sequentiele commandos is dit dus niet nodig
// 18 staat voor een cijfer tussen 1 en 8, welke gedefined zijn
// AH staat voor een letter tussen A en H, welke gedefined zijn
// Het eerste deel betreft punt 1, het tweede deel punt 2
// Wanneer 1 opdracht is uitgevoerd stuurd de Arduino een bericht terug naar Visual Studio, waarna Visual Studio een nieuwe commando stuurt
 while(Serial.available())
  {
  data[aantal]=Serial.read();
  if(data[aantal]=='%')
  {
    aantal=-1;
    for(int y=0;y<50;y++)
    {
      data[y]=' ';
    }
  }
  aantal++;

  for(int u=0;u<50;u++)
  {
    Serial1.print(data[u]);
  }
  Serial1.println("Woord");
}

void Beweging(Z,18a,AHa,OffXa,OffXb,18b,AHb,OffXa,OffXb)
{
if(Za=!Z) //Als Z niet doorgegeven is
{
  Z.write(Down);
  delay(tijd);
  X.write(AHa);
  Y.write(18a);
  delay(anderetijd);
  X.write(AHa+OffXa);
  Y.write(18a+OffYa);
  Z.write(Up);
  
}
X.write(AHb+OffYb);
delay(tijd);
y.write(18b+OffXb);
delay(tijd);

  }

