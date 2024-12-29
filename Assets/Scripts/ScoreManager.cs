using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using TMPro;

public class ScoreManager
{
    private static ScoreManager instance; // Singleton instance
    private int puntos;
    public TextMeshProUGUI pointsText;

    // Evento para notificar cambios en los puntos
    public event Action<int> OnScoreChanged;

    // Constructor privado para Singleton
    private ScoreManager()
    {
        puntos = 190; // Inicializar puntos
    }

    // M�todo para obtener la instancia
    public static ScoreManager Instance
    {
        get
        {
            if (instance == null)
                instance = new ScoreManager();
            return instance;
        }
    }

    // M�todo para a�adir puntos
    public void AddPoints(int cantidad)
    {
        puntos += cantidad;
        OnScoreChanged?.Invoke(puntos); // Notificar cambio
    }


    // M�todo para gastar puntos
    public bool SpendPoints(int cantidad)
    {
        if (puntos >= cantidad)
        {
            puntos -= cantidad;
            OnScoreChanged?.Invoke(puntos); // Notificar cambio
            return true;
        }

        return false; // No hay puntos suficientes
    }

    // M�todo para obtener los puntos actuales
    public int GetPoints()
    {
        return puntos;
    }
}
