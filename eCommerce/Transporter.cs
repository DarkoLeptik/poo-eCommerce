using System;
using System.Collections.Generic;

class Transporter{

    public Transporter(){
        
    }

    Move(Planet[] planets, Ship ship){
        if(ship.currentAction == leave){
            for(int i = 0; i<ship.itineraire.Length; i++){
                if(ship.position == ship.itineraire[i]){
                    /*
                    for(int j = 0; j < planets.Length; j++){
                        if(planets[j].id == ship.position){
                            planets[j].TakeOff[ship];
                        } 
                    }
                    */
                    ship.position = ship.itineraire[i+1];
                }
            }
            
        }
        else if(ship.currentAction == noAction){
            //TODO Deplacer le ship de la place d'attente vers le port
            //TODO Faire atterir les vaisseaux
        }
        //TODO Land(ship);
    }


    //TODO ADD CODE BELOW IN UNIVERSE
    /*
    foreach(Ship ship in ships){
        Move(planets, ship);
    }
    */
    
}