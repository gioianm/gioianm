using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrilliantApplication.ControlSystems
{
    public class NelderMeadMethod
    {
        const int a = 1;
        const int NP = 3; // NP - число аргументов функции
        double[,] simplex = new double[NP, NP + 1]; // NP + 1 - число вершин симплекса
        double[] FN = new double[NP + 1];
       const double L = 0.7; // Начальная длина ребра симплекса
        const double L_thres = 1.0e-5; // Предельное значение длины ребра симплекса
        const double cR = 1.0; // Коэффициент отражения симплекса
        const double alpha = 1.0; // Коэффициент растяжения симплекса
        const double beta = 0.5; // Коэффициент сжатия симплекса
        const double gamma = 0.5; // Коэффициент редукции симплекса
      
            private double F(double[] Kbase,int NP)
        {
            double dt = 0.1;
            TankControlSystem sys = new TankControlSystem(dt);
            sys.Regulator.RewriteConfig(Kbase);
            double sum = 0;
            int cnt = (int)(400 / dt);
            for (int i = 0; i < cnt; i++)
            {
                sum += 0.5*(Math.Pow(i-1,a)+Math.Pow(i,a))*(Math.Pow(sys.CalculateWaterLevel(), 2)+ Math.Pow(sys.CalculateWaterLevel(), 2)) * dt;
            }
            return sum;
        }
        private void makeSimplex(double[] X, double L, int NP, bool first)
        {
            double qn, q2, r1, r2;
            int i, j;
            qn = Math.Sqrt(1.0 + NP) - 1.0;
            q2 = L / Math.Sqrt(2.0) * (double)NP;
            r1 = q2 * (qn + (double)NP);
            r2 = q2 * qn;
            for (i = 0; i < NP; i++) simplex[i, 0] = X[i];
            for (i = 1; i < NP + 1; i++)
                for (j = 0; j < NP; j++)
                    simplex[j, i] = X[j] + r2;
            for (i = 1; i < NP + 1; i++) simplex[i - 1, i] = simplex[i - 1, i] - r2 + r1;
            for (i = 0; i < NP + 1; i++)
            {
                for (j = 0; j < NP; j++) X[j] = simplex[j, i];
                FN[i] = F(X, NP); // Значения функции в вершинах начального симплекса
            }
           
        }
        private double[] center_of_gravity(int k, int NP) // Центр тяжести симплекса
        {
            int i, j;
            double s;
            double[] xc = new double[NP];
            for (i = 0; i < NP; i++)
            {
                s = 0;
                for (j = 0; j < NP + 1; j++) s += simplex[i, j];
                xc[i] = s;
            }
            for (i = 0; i < NP; i++) xc[i] = (xc[i] - simplex[i, k]) / (double)NP;
            return xc;
        }
        private void reflection(int k, double cR, int NP) // Отражение вершины с номером k относительно центра тяжести
        {
            double[] xc = center_of_gravity(k, NP); // cR – коэффициент отражения
            for (int i = 0; i < NP; i++) simplex[i, k] = (1.0 + cR) * xc[i] - simplex[i, k];
        }
        private void reduction(int k, double gamma, int NP) // Редукция симплекса к вершине k
        {
            int i, j; // gamma – коэффициент редукции
            double[] xk = new double[NP];
            for (i = 0; i < NP; i++) xk[i] = simplex[i, k];
            for (j = 0; j < NP; j++)
                for (i = 0; i < NP; i++)
                    simplex[i, j] = xk[i] + gamma * (simplex[i, j] - xk[i]);
            for (i = 0; i < NP; i++) simplex[i, k] = xk[i]; // Восстанавливаем симплекс в вершине k
        }
        private void shrinking_expansion(int k, double alpha_beta, int NP) // Сжатие/растяжение симплекса. alpha_beta – коэффициент растяжения/сжатия
        {
            double[] xc = center_of_gravity(k, NP);
            for (int i = 0; i < NP; i++)
                simplex[i, k] = xc[i] + alpha_beta * (simplex[i, k] - xc[i]);
        }
        private double findL(double[] X2, int NP) // Длиина ребра симплекса
        {
            double L = 0;
            for (int i = 0; i < NP; i++) L += X2[i] * X2[i];
            return Math.Sqrt(L);
        }
        private double minval(double[] F, int N1, ref int imi) // Минимальный элемент массива и его индекс
        {
            double fmi = double.MaxValue, f;
            for (int i = 0; i < N1; i++)
            {
                f = F[i];
                if (f < fmi)
                {
                    fmi = f;
                    imi = i;
                }
            }
            return fmi;
        }
        private double maxval(double[] F, int N1, ref int ima) // Максимальный элемент массива и его индекс
        {
            double fma = double.MinValue, f;
            for (int i = 0; i < N1; i++)
            {
                f = F[i];
                if (f > fma)
                {
                    fma = f;
                    ima = i;
                }
            }
            return fma;
        }
        private void simplexRestore(int NP) // Восстанавление симплекса
        {
            int i, imi = -1, imi2 = 0;
            double fmi, fmi2 = double.MaxValue, f;
            double[] X = new double[NP], X2 = new double[NP];
            fmi = minval(FN, NP + 1, ref imi);
            for (i = 0; i < NP + 1; i++)
            {
                f = FN[i];
                if (f != fmi && f < fmi2)
                {
                    fmi2 = f;
                    imi2 = i;
                }
            }
            for (i = 0; i < NP; i++)
            {
                X[i] = simplex[i, imi];
                X2[i] = simplex[i, imi] - simplex[i, imi2];
            }
            makeSimplex(X, findL(X2, NP), NP, false);
        }
        private bool notStopYet(double L_thres, int NP) // Возвращает true, если длина хотя бы одного ребра симплекса превышает L_thres, или false - в противном случае
        {
            int i, j, k;
            double[] X = new double[NP], X2 = new double[NP];
            for (i = 0; i < NP; i++)
            {
                for (j = 0; j < NP; j++) X[j] = simplex[j, i];
                for (j = i + 1; j < NP + 1; j++)
                {
                    for (k = 0; k < NP; k++) X2[k] = X[k] - simplex[k, j];
                    if (findL(X2, NP) > L_thres) return true;
                }
            }
            return false;
        }
        // Выполняет поиск экстремума (минимума) функции F
        public double[] nelMead(ref double[] X)
        {
            int i, j2, imi = -1, ima = -1;
            int j = 0, kr = 0, jMx = 10000; // Предельное число шагов алгоритма (убрать после отладки)
            double[] X2 = new double[NP], X_R = new double[NP];
            double Fmi, Fma, F_R, F_S, F_E;
            const int kr_todo = 60; // kr_todo - число шагов алгоритма, после выполнения которых симплекс восстанавливается
            makeSimplex(X, L, NP, true);
            while (notStopYet(L_thres, NP) && j < jMx)
            {
                j++; // Число итераций
                kr++;
                if (kr == kr_todo)
                {
                    kr = 0;
                    simplexRestore(NP); // Восстановление симплекса
                }
                Fmi = minval(FN, NP + 1, ref imi);
                Fma = maxval(FN, NP + 1, ref ima); // ima - Номер отражаемой вершины
                for (i = 0; i < NP; i++) X[i] = simplex[i, ima];
                reflection(ima, cR, NP); // Отражение
                for (i = 0; i < NP; i++) X_R[i] = simplex[i, ima];
                F_R = F(X_R, NP); // Значение функции в вершине ima симплекса после отражения
                if (F_R > Fma)
                {
                    shrinking_expansion(ima, beta, NP); // Сжатие
                    for (i = 0; i < NP; i++) X2[i] = simplex[i, ima];
                    F_S = F(X2, NP); // Значение функции в вершине ima симплекса после его сжатия
                    if (F_S > Fma)
                    {
                        for (i = 0; i < NP; i++) simplex[i, ima] = X[i];
                        reduction(ima, gamma, NP); // Редукция
                        for (i = 0; i < NP + 1; i++)
                        {
                            if (i == ima) continue;
                            for (j2 = 0; j2 < NP; j2++) X2[j2] = simplex[j2, i];
                            // Значения функций в вершинах симплекса после редукции. В вершине ima значение функции сохраняется
                            FN[i] = F(X2, NP);
                        }
                    }
                    else
                        FN[ima] = F_S;
                }
                else if (F_R < Fmi)
                {
                    shrinking_expansion(ima, alpha, NP); // Растяжение
                    for (j2 = 0; j2 < NP; j2++) X2[j2] = simplex[j2, ima];
                    F_E = F(X2, NP); // Значение функции в вершине ima симплекса после его растяжения
                    if (F_E > Fmi)
                    {
                        for (j2 = 0; j2 < NP; j2++) simplex[j2, ima] = X_R[j2];
                        FN[ima] = F_R;
                    }
                    else
                        FN[ima] = F_E;
                }
                else
                    FN[ima] = F_R;
            }
            return X;
        }
             
    }
}

