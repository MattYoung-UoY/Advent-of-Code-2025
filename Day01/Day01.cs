using System.IO;

// string[] fileContents = File.ReadAllLines("Day01_ex_inp.txt");
string[] fileContents = File.ReadAllLines("Day01_inp.txt");

int dialValue = 50;
int key = 0;

for (int i = 0; i < fileContents.Length; i++)
{
    Console.WriteLine(fileContents[i]);

    char[] currentInstrCharArr = fileContents[i].ToCharArray();

    string moveDistanceStr = "";
    for (int j = 1; j < currentInstrCharArr.Length; j++)
    {
        moveDistanceStr += currentInstrCharArr[j];
    }

    int moveDistance = Int32.Parse(moveDistanceStr);
    char moveDirection = currentInstrCharArr[0];

    // Add on the moveDir
    if(moveDirection == 'R')
    {
        while(moveDistance > 99)
        {
            key++;
            Console.WriteLine("Adding 100. Key: " + key);
            moveDistance -= 100;
        }

        Console.WriteLine("Pre increment dial val: " + dialValue);

        dialValue += moveDistance;
        
        Console.WriteLine("Post increment dial val: " + dialValue);

        if(dialValue > 99)
        {
            dialValue -= 100;
            key++;
            Console.WriteLine("Overflow. Key: " + key);
        }

    }
    else
    {
        while(moveDistance > 99)
        {
            key++;
            Console.WriteLine("Subtracting 100. Key: " + key);
            moveDistance -= 100;
        }

        dialValue -= moveDistance;

        if(dialValue < 0)
        {
            if(Math.Abs(dialValue) != moveDistance){
                key++;
                Console.WriteLine("Underflow. Key: " + key);
            }
            dialValue += 100;
        }

        if(dialValue == 0) key++;
    }

    Console.WriteLine("Dial @ " + dialValue);
    Console.WriteLine("-------------------------------------");

}

Console.WriteLine(key);