﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA2
{
    /**
     * Die Klasse Signal reprÃ¤sentiert ein Signal das nur aus drei Signalen zur verfuegung Steht: 
     * kurz, mittel und lang
     * Jedes Signal hat eine mindest und maximal lÃ¤nge
     * @author thomas
     */
    public enum SignalTyp
    {
        KURZ,
        MITTEL,
        LANG,
        NODATA
    }

    public class Signal
    {

        /*if (minM < maxK) {
        minM = maxK;
        maxM = maxK;
    }*/

        private SignalTyp type;
        private int time;           // Zeit in ms
        private string signalCode;  // 
        private char[] cSignalCode; // 
        private int iNull;          // Anzahl der Nullen
        private int iEins;          // Anzahl der Einsen
        private int begin;          // MinimalZeit fÃ¼r den Typ von Signal
        private int end;                // MaximalZeit fÃ¼r den Typ von Signal

        /**
         * erzeugt ein Signal, dass mit der genannten Zeit
         * @param sTime Zeit in ms
         */
        public Signal(int sTime)
        {
            type = SignalTyp.NODATA;
            time = sTime;
            init();
        }

        /**
         * Konstruktor des Signals
         * @param sType Signaltyp 
         * @param sTime Zeit in ms, die sich in dem Intervall des Signaltyps befinden soll
         */
        public Signal(SignalTyp sType, int sTime)
        {
            type = sType;
            time = sTime;
            //cSignalCode = new char [(end/5)];
            init();
        }

        /**
         * Initialisierungsmethode
         */
        private void init()
        {
            rightTime();
            calculate();
            createString();     // erzeuge den Code
        }

        /**
         * es wird fuer jeden Signaltyp die Intervallgrenzen bestimmt
         */
        private void rightTime()
        {
            switch (type)
            {
                case SignalTyp.KURZ:
                    begin = MainProgram.MINKURZTIME;
                    end = MainProgram.MAXKURZTIME;
                break;
                case SignalTyp.MITTEL:
                    begin = MainProgram.MINMITTELTIME;
                    end = MainProgram.MAXMITTELTIME;
                break;
                case SignalTyp.LANG:
                    begin = MainProgram.MINLANGTIME;
                    end = MainProgram.MAXLANGTIME;
                break;
                case SignalTyp.NODATA:
                    begin = MainProgram.MINTIME;
                    end = MainProgram.MAXTIME;
                break;
            }
        }

        /**
         * Berechnet die Anzahl der Einsen und Nullen
         */
        private void calculate()
        {
            iEins = time / 5;
            iNull = (end / 5) - (time / 5);
        }

        private void createString()
        {
            char[] test = new char[(end / 5)];
            for (int i = 0; i < iEins; i++)
            {
                test[i] = '1';
            }

            for (int i = iEins; i < (end / 5); i++)
            {
                test[i] = '0';
            }

            cSignalCode = test;
            signalCode = new string(cSignalCode);
            // Ausgabe
            Console.WriteLine("Ausgabe von caltulateString() Zeit : " + time + " berechnete einsen " + iEins + " daraus folgt "
                    + getEins() + " Code = ");
            Console.WriteLine(signalCode);
        }

        /**
         * erstellt den neuen String und gibt ihn Aus.
         */
        public void printString()
        {
            createString();
        }

        /**
         * Setze die Anzahl (n) an Nullen
         * @param n Anzahl Einsen die gesetzt werden soll
         */
        public void setEins(int n)
        {
            iEins = n;
        }

        /**
         * setzt die Anzahl (n) an Nullen
         * @param n Anzahl Nullen die gesetzt werden soll
         */
        public void setNull(int n)
        {
            iNull = n;
        }

        /**
         * setzt den Typen des Signals 
         * @param sType ist der Typ der gesetzt werden soll
         */
        public void setType(SignalTyp sType)
        {
            type = sType;
        }

        /**
         * gibt die Anzahl der Einsen an
         * @return
         */
        public int getEins()
        {
            return iEins;
        }

        /**
         * gibt die Anzahl der Nullen an 
         * @return
         */
        public int getNull()
        {
            return iNull;
        }

        /**
         * gibt den Typ des Signals zurueck
         * @return
         */
        public SignalTyp getType()
        {
            return type;
        }

        /**
         * gibt die Zeit des Signals von dem Signaltyp zurueck  
         * @return
         */
        public int getTime()
        {
            return time;
        }

        /**
         * Gibt die Mindestzeit des Intervalls des Signalstypen an
         * @return
         */
        public int minTime()
        {
            return begin;
        }

        /**
         * gibt den Endzeitpunkt des Intervalls dieses Signaltyps an
         * @return
         */
        public int maxTime()
        {
            return end;
        }

        // Anzahl Einsen
        /*public int countOnce() {
			//int temp = signalCode.length() - signalCode.replace("1", "").length();
			return iEins;
		}*/
    }
}
