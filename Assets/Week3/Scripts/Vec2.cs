using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Creating a custom class for Vector2
public class Vec2{
    public float x = 0f, y = 0f;
    
    //Empty Constructor
    public Vec2(){
        x = 0f; 
        y = 0f;
    }

    //Constructor with arguments
    public Vec2(float a_x, float a_y){
        x = a_x;
        y = a_y;
    }

    //Function to convert into Vector2
    public Vector2 toVector2(){
        return new Vector2(x, y);
    }

    //Function to convert into Vector3
    public Vector3 toVector3(){
        return new Vector3(x, y, 0f);
    }

    //Creating own overload operators (combining vectors)
    public static Vec2 operator +(Vec2 a, Vec2 b){
        return new Vec2(a.x + b.x, a.y + b.y);
    }
    public static Vec2 operator -(Vec2 a, Vec2 b){
        return new Vec2(a.x - b.x, a.y - b.y);
    }
    public static Vec2 operator *(Vec2 a, Vec2 b){
        return new Vec2(a.x * b.x, a.y * b.y);
    }
    
    //Increasing vector by a scalar value
    public static Vec2 operator *(Vec2 a, float s){
        return new Vec2(a.x * s, a.y * s);
    }

    public static Vec2 operator -(Vec2 a){
        return new Vec2(-a.x, -a.y);
    }

    //Magnitude
    public float Mag(){
        return Mathf.Sqrt(x * x + y * y);
    }

    //Magnitude with out square root
    public float MagSqr(){
        return x * x + y * y;
    }

    //Dot product methods
    public float Dotproduct1(Vec2 a_b){
        //A.B = a.x * b.x + a.y * b.y
        return x * a_b.x + y * a_b.y;
    }
    public static float Dotproduct2(Vec2 a, Vec2 b){
        //A.B = a.x * b.x + a.y * b.y
        return a.x * b.x + a.y * b.y;
    }
    
    //Normalising a Vec2
    public Vec2 Normalise(Vec2 a, Vec2 b)
    {
        //nA = (x/lA, y/lA)
        float length = Mag();
        return new Vec2(x / length, y / length);
    }

    //Perpendicular vec2
    public Vec2 Perpendicular(){
        return new Vec2(y, -x);
    }

    //Rotate vec2 around z-axis
}
