# Easing Functions For C# and Unity
Implementation of Easing Functions within Unity in C#

Sine, Quad, Cubic, Quint, Expo, Circ, Back, Elastic & Bounce each with there in and out variants. 



# Usage 

All easing functions can be called from the following static function 

    EasingLerps.EasingLerp(EasingLerpsType type, EasingInOutType inOutType, float time, float a, float b)

Where 
    type being type of easing to use (Sine, Quad ect)
    inOutType being which variant for use
    time being the time between 0 and 1
    a being the start lerp value 
    b being the ending lerp value

with it returning a float value between a and b for the given time value.

# Demo

All functionality can be played around with from the EasingLerpExample example scene. 

Loading and playing this scene will allow you to jump between each type of easing function along with it's in & out variation.


# License

Developed by Alan Yeats with a zlib license. While the zlib license does not require acknowledgement.
