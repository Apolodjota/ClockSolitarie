using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckScript : MonoBehaviour{
    public List<string> deck = new List<string>();
    public Dictionary<int, List<string>> kHands = new Dictionary<int, List<string>>();
        

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
       var card = "AC";
       
       // H es corazones o hearts
       // C es treboles o clubs
       // D es diamantes o diamonds
       // S es picas o spades
       var suits = new string[]{"H", "C", "D", "S"};
       var values = new List<string>(){"A", "2", "3", "4", "5",
        "6", "7", "8", "9", "T", "J", "Q", "K"};
       
       //Creamos el deck de 52 cartas
       foreach(var suit in suits){
           foreach(var value in values){
               deck.Add($"{suit}{value}");
           }
       }

       // Barajeamos el deck
       Suffle();
       Clock();

       foreach (var key in kHands.Keys){
          Debug.Log($"Hand {key}: {string.Join(", ", kHands[key])}");
       }
          
    }
    void Suffle(){
       AmericanSuffle();
       AmericanSuffle();
       AmericanSuffle();
       AmericanSuffle();
       AmericanSuffle();
       AmericanSuffle();
       AmericanSuffle();
       AmericanSuffle();
       AmericanSuffle();
    }
    void AmericanSuffle(){
        var random = new System.Random();
        for (int i = 0; i < deck.Count; i++){
            var mitad = deck.Count/2;
            var izq = deck.GetRange(0, mitad);
            var der = deck.GetRange(mitad, deck.Count - mitad);
            deck.Clear();
            while (izq.Count > 0 || der.Count > 0){
                if(izq.Count > 0){
                    var randomIndex = random.Next(0, izq.Count);
                    deck.Add(izq[randomIndex]);
                    izq.RemoveAt(randomIndex);
                }
                if(der.Count > 0){
                    var randomIndex = random.Next(0, der.Count);
                    deck.Add(der[randomIndex]);
                    der.RemoveAt(randomIndex);
                }
            }
        }
    }

    void Clock(){
        for (int i = 1; i <= 13; i++){
            kHands.Add(i, new List<string>());
            for (int j = 0; j < 4; j++){
                kHands[i].Add(deck[0]);
                deck.RemoveAt(0);
            }
        }
    }

}
