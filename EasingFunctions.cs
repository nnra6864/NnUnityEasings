// Modified by nnra

/*
 * Created by C.J. Kimberlin
 *
 * The MIT License (MIT)
 *
 * Copyright (c) 2019
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 *
 * TERMS OF USE - EASING EQUATIONS
 * Open source under the BSD License.
 * Copyright (c)2001 Robert Penner
 * All rights reserved.
 * Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
 * Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
 * Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
 * Neither the name of the author nor the names of contributors may be used to endorse or promote products derived from this software without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO,
 * THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE
 * FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
 * LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 * (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 *
 *
 * ============= Description =============
 *
 * Below is an example of how to use the easing functions in the file. There is a getting function that will return the function
 * from an enum. This is useful since the enum can be exposed in the editor and then the function queried during Start().
 *
 * Easings.Type ease = Easings.Type.QuadInOut;
 * Easings.EasingFunc func = GetEasingFunction(ease;
 *
 * float value = func(0, 10, 0.67f);
 *
 * Easings.EasingFunc derivativeFunc = GetEasingFunctionDerivative(ease);
 *
 * float derivativeValue = derivativeFunc(0, 10, 0.67f);
 */

using UnityEngine;

namespace NnUnityEasings
{
    public static class Easings
    {
        private const float NaturalLOGOf2 = 0.693147181f;

        //
        // Type functions
        //

        public static float Linear(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            return Mathf.Lerp(start, end, value);
        }

        public static float Spring(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            value = Mathf.Clamp01(value);
            value = (Mathf.Sin(value * Mathf.PI * (0.2f + 2.5f * value * value * value)) *
                     Mathf.Pow(1f - value, 2.2f) + value) * (1f + (1.2f * (1f - value)));
            return start + (end - start) * value;
        }

        public static float QuadIn(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            end -= start;
            return end * value * value + start;
        }

        public static float QuadOut(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            end -= start;
            return -end * value * (value - 2) + start;
        }

        public static float QuadInOut(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            value /= .5f;
            end -= start;
            if (value < 1) return end * 0.5f * value * value + start;
            value--;
            return -end * 0.5f * (value * (value - 2) - 1) + start;
        }

        public static float CubicIn(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            end -= start;
            return end * value * value * value + start;
        }

        public static float CubicOut(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            value--;
            end -= start;
            return end * (value * value * value + 1) + start;
        }

        public static float CubicInOut(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            value /= .5f;
            end -= start;
            if (value < 1) return end * 0.5f * value * value * value + start;
            value -= 2;
            return end * 0.5f * (value * value * value + 2) + start;
        }

        public static float QuartIn(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            end -= start;
            return end * value * value * value * value + start;
        }

        public static float QuartOut(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            value--;
            end -= start;
            return -end * (value * value * value * value - 1) + start;
        }

        public static float QuartInOut(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            value /= .5f;
            end -= start;
            if (value < 1) return end * 0.5f * value * value * value * value + start;
            value -= 2;
            return -end * 0.5f * (value * value * value * value - 2) + start;
        }

        public static float QuintIn(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            end -= start;
            return end * value * value * value * value * value + start;
        }

        public static float QuintOut(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            value--;
            end -= start;
            return end * (value * value * value * value * value + 1) + start;
        }

        public static float QuintInOut(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            value /= .5f;
            end -= start;
            if (value < 1) return end * 0.5f * value * value * value * value * value + start;
            value -= 2;
            return end * 0.5f * (value * value * value * value * value + 2) + start;
        }

        public static float SineIn(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            end -= start;
            return -end * Mathf.Cos(value * (Mathf.PI * 0.5f)) + end + start;
        }

        public static float SineOut(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            end -= start;
            return end * Mathf.Sin(value * (Mathf.PI * 0.5f)) + start;
        }

        public static float SineInOut(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            end -= start;
            return -end * 0.5f * (Mathf.Cos(Mathf.PI * value) - 1) + start;
        }

        public static float ExpoIn(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            end -= start;
            return end * Mathf.Pow(2, 10 * (value - 1)) + start;
        }

        public static float ExpoOut(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            end -= start;
            return end * (-Mathf.Pow(2, -10 * value) + 1) + start;
        }

        public static float ExpoInOut(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            value /= .5f;
            end -= start;
            if (value < 1) return end * 0.5f * Mathf.Pow(2, 10 * (value - 1)) + start;
            value--;
            return end * 0.5f * (-Mathf.Pow(2, -10 * value) + 2) + start;
        }

        public static float CircIn(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            end -= start;
            return -end * (Mathf.Sqrt(1 - value * value) - 1) + start;
        }

        public static float CircOut(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            value--;
            end -= start;
            return end * Mathf.Sqrt(1 - value * value) + start;
        }

        public static float CircInOut(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            value /= .5f;
            end -= start;
            if (value < 1) return -end * 0.5f * (Mathf.Sqrt(1 - value * value) - 1) + start;
            value -= 2;
            return end * 0.5f * (Mathf.Sqrt(1 - value * value) + 1) + start;
        }

        public static float BounceIn(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            end -= start;
            float d = 1f;
            return end - BounceOut(0, end, d - value) + start;
        }

        public static float BounceOut(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            value /= 1f;
            end -= start;
            if (value < (1 / 2.75f))
            {
                return end * (7.5625f * value * value) + start;
            }

            if (value < (2 / 2.75f))
            {
                value -= (1.5f / 2.75f);
                return end * (7.5625f * (value) * value + .75f) + start;
            }

            if (value < (2.5 / 2.75))
            {
                value -= (2.25f / 2.75f);
                return end * (7.5625f * (value) * value + .9375f) + start;
            }

            value -= (2.625f / 2.75f);
            return end * (7.5625f * (value) * value + .984375f) + start;
        }

        public static float BounceInOut(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            end -= start;
            float d = 1f;
            if (value < d * 0.5f) return BounceIn(0, end, value * 2) * 0.5f + start;
            return BounceOut(0, end, value * 2 - d) * 0.5f + end * 0.5f + start;
        }

        public static float BackIn(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            end -= start;
            value /= 1;
            float s = 1.70158f;
            return end * (value) * value * ((s + 1) * value - s) + start;
        }

        public static float BackOut(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            float s = 1.70158f;
            end -= start;
            value = (value) - 1;
            return end * ((value) * value * ((s + 1) * value + s) + 1) + start;
        }

        public static float BackInOut(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            float s = 1.70158f;
            end -= start;
            value /= .5f;
            if ((value) < 1)
            {
                s *= (1.525f);
                return end * 0.5f * (value * value * (((s) + 1) * value - s)) + start;
            }

            value -= 2;
            s *= (1.525f);
            return end * 0.5f * ((value) * value * (((s) + 1) * value + s) + 2) + start;
        }

        public static float ElasticIn(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            end -= start;

            float d = 1f;
            float p = d * .3f;
            float s;
            float a = 0;

            if (value == 0) return start;

            if (Mathf.Approximately((value /= d), 1)) return start + end;

            if (a == 0f || a < Mathf.Abs(end))
            {
                a = end;
                s = p / 4;
            }
            else
            {
                s = p / (2 * Mathf.PI) * Mathf.Asin(end / a);
            }

            return -(a * Mathf.Pow(2, 10 * (value -= 1)) *
                     Mathf.Sin((value * d - s) * (2 * Mathf.PI) / p)) + start;
        }

        public static float ElasticOut(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            end -= start;

            float d = 1f;
            float p = d * .3f;
            float s;
            float a = 0;

            if (value == 0) return start;

            if (Mathf.Approximately((value /= d), 1)) return start + end;

            if (a == 0f || a < Mathf.Abs(end))
            {
                a = end;
                s = p * 0.25f;
            }
            else
            {
                s = p / (2 * Mathf.PI) * Mathf.Asin(end / a);
            }

            return (a * Mathf.Pow(2, -10 * value) *
                    Mathf.Sin((value * d - s) * (2 * Mathf.PI) / p) + end + start);
        }

        public static float ElasticInOut(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            end -= start;

            float d = 1f;
            float p = d * .3f;
            float s;
            float a = 0;

            if (value == 0) return start;

            if (Mathf.Approximately((value /= d * 0.5f), 2)) return start + end;

            if (a == 0f || a < Mathf.Abs(end))
            {
                a = end;
                s = p / 4;
            }
            else
            {
                s = p / (2 * Mathf.PI) * Mathf.Asin(end / a);
            }

            if (value < 1)
                return -0.5f * (a * Mathf.Pow(2, 10 * (value -= 1)) *
                                Mathf.Sin((value * d - s) * (2 * Mathf.PI) / p)) + start;
            return a * Mathf.Pow(2, -10 * (value -= 1)) *
                   Mathf.Sin((value * d - s) * (2 * Mathf.PI) / p) * 0.5f + end + start;
        }

        //
        // These are derived functions that the motor can use to get the speed at a specific time.
        //
        // The easing functions all work with a normalized time (0 to 1) and the returned value here
        // reflects that. Values returned here should be divided by the actual time.
        //

        public static float LinearD(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            return end - start;
        }

        public static float QuadInD(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            return 2f * (end - start) * value;
        }

        public static float QuadOutD(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            end -= start;
            return -end * value - end * (value - 2);
        }

        public static float QuadInOutD(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            value /= .5f;
            end -= start;

            if (value < 1)
            {
                return end * value;
            }

            value--;

            return end * (1 - value);
        }

        public static float CubicInD(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            return 3f * (end - start) * value * value;
        }

        public static float CubicOutD(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            value--;
            end -= start;
            return 3f * end * value * value;
        }

        public static float CubicInOutD(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            value /= .5f;
            end -= start;

            if (value < 1)
            {
                return (3f / 2f) * end * value * value;
            }

            value -= 2;

            return (3f / 2f) * end * value * value;
        }

        public static float QuartInD(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            return 4f * (end - start) * value * value * value;
        }

        public static float QuartOutD(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            value--;
            end -= start;
            return -4f * end * value * value * value;
        }

        public static float QuartInOutD(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            value /= .5f;
            end -= start;

            if (value < 1)
            {
                return 2f * end * value * value * value;
            }

            value -= 2;

            return -2f * end * value * value * value;
        }

        public static float QuintInD(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            return 5f * (end - start) * value * value * value * value;
        }

        public static float QuintOutD(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            value--;
            end -= start;
            return 5f * end * value * value * value * value;
        }

        public static float QuintInOutD(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            value /= .5f;
            end -= start;

            if (value < 1)
            {
                return (5f / 2f) * end * value * value * value * value;
            }

            value -= 2;

            return (5f / 2f) * end * value * value * value * value;
        }

        public static float SineInD(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            return (end - start) * 0.5f * Mathf.PI * Mathf.Sin(0.5f * Mathf.PI * value);
        }

        public static float SinceOutD(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            end -= start;
            return (Mathf.PI * 0.5f) * end * Mathf.Cos(value * (Mathf.PI * 0.5f));
        }

        public static float SineInOutD(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            end -= start;
            return end * 0.5f * Mathf.PI * Mathf.Sin(Mathf.PI * value);
        }

        public static float ExpoInD(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            return (10f * NaturalLOGOf2 * (end - start) * Mathf.Pow(2f, 10f * (value - 1)));
        }

        public static float ExpoOutD(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            end -= start;
            return 5f * NaturalLOGOf2 * end * Mathf.Pow(2f, 1f - 10f * value);
        }

        public static float ExpoInOutD(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            value /= .5f;
            end -= start;

            if (value < 1)
            {
                return 5f * NaturalLOGOf2 * end * Mathf.Pow(2f, 10f * (value - 1));
            }

            value--;

            return (5f * NaturalLOGOf2 * end) / (Mathf.Pow(2f, 10f * value));
        }

        public static float CircInD(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            return ((end - start) * value) / Mathf.Sqrt(1f - value * value);
        }

        public static float CircOutD(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            value--;
            end -= start;
            return (-end * value) / Mathf.Sqrt(1f - value * value);
        }

        public static float CircInOutD(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            value /= .5f;
            end -= start;

            if (value < 1)
            {
                return (end * value) / (2f * Mathf.Sqrt(1f - value * value));
            }

            value -= 2;

            return (-end * value) / (2f * Mathf.Sqrt(1f - value * value));
        }

        public static float BounceInD(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            end -= start;
            float d = 1f;

            return BounceOutD(0, end, d - value);
        }

        public static float BounceOutD(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            value /= 1f;
            end -= start;

            if (value < (1 / 2.75f))
            {
                return 2f * end * 7.5625f * value;
            }

            if (value < (2 / 2.75f))
            {
                value -= (1.5f / 2.75f);
                return 2f * end * 7.5625f * value;
            }

            if (value < (2.5 / 2.75))
            {
                value -= (2.25f / 2.75f);
                return 2f * end * 7.5625f * value;
            }

            value -= (2.625f / 2.75f);
            return 2f * end * 7.5625f * value;
        }

        public static float BounceInOutD(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            end -= start;
            float d = 1f;

            if (value < d * 0.5f)
            {
                return BounceInD(0, end, value * 2) * 0.5f;
            }

            return BounceOutD(0, end, value * 2 - d) * 0.5f;
        }

        public static float BackInD(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            float s = 1.70158f;

            return 3f * (s + 1f) * (end - start) * value * value - 2f * s * (end - start) * value;
        }

        public static float BackOutD(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            float s = 1.70158f;
            end -= start;
            value = (value) - 1;

            return end * ((s + 1f) * value * value + 2f * value * ((s + 1f) * value + s));
        }

        public static float BackInOutD(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            float s = 1.70158f;
            end -= start;
            value /= .5f;

            if ((value) < 1)
            {
                s *= (1.525f);
                return 0.5f * end * (s + 1) * value * value + end * value * ((s + 1f) * value - s);
            }

            value -= 2;
            s *= (1.525f);
            return 0.5f * end * ((s + 1) * value * value + 2f * value * ((s + 1f) * value + s));
        }

        public static float ElasticInD(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            return ElasticOutD(start, end, 1f - value);
        }

        public static float ElasticOutD(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            end -= start;

            float d = 1f;
            float p = d * .3f;
            float s;
            float a = 0;

            if (a == 0f || a < Mathf.Abs(end))
            {
                a = end;
                s = p * 0.25f;
            }
            else
            {
                s = p / (2 * Mathf.PI) * Mathf.Asin(end / a);
            }

            return (a * Mathf.PI * d * Mathf.Pow(2f, 1f - 10f * value) *
                    Mathf.Cos((2f * Mathf.PI * (d * value - s)) / p)) / p - 5f * NaturalLOGOf2 * a *
                   Mathf.Pow(2f, 1f - 10f * value) *
                   Mathf.Sin((2f * Mathf.PI * (d * value - s)) / p);
        }

        public static float ElasticInOutD(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            end -= start;

            float d = 1f;
            float p = d * .3f;
            float s;
            float a = 0;

            if (a == 0f || a < Mathf.Abs(end))
            {
                a = end;
                s = p / 4;
            }
            else
            {
                s = p / (2 * Mathf.PI) * Mathf.Asin(end / a);
            }

            if (value < 1)
            {
                value -= 1;

                return -5f * NaturalLOGOf2 * a * Mathf.Pow(2f, 10f * value) *
                       Mathf.Sin(2 * Mathf.PI * (d * value - 2f) / p) -
                       a * Mathf.PI * d * Mathf.Pow(2f, 10f * value) *
                       Mathf.Cos(2 * Mathf.PI * (d * value - s) / p) / p;
            }

            value -= 1;

            return a * Mathf.PI * d * Mathf.Cos(2f * Mathf.PI * (d * value - s) / p) /
                   (p * Mathf.Pow(2f, 10f * value)) -
                   5f * NaturalLOGOf2 * a * Mathf.Sin(2f * Mathf.PI * (d * value - s) / p) /
                   (Mathf.Pow(2f, 10f * value));
        }

        public static float SpringD(float value, float start = 0, float end = 1)
        {
            if (value is 0 or 1) return value;

            value = Mathf.Clamp01(value);
            end -= start;

            // Damn... Thanks http://www.derivative-calculator.net/
            // TODO: And it's a little bit wrong
            return end * (6f * (1f - value) / 5f + 1f) * (-2.2f * Mathf.Pow(1f - value, 1.2f) *
                                                          Mathf.Sin(
                                                              Mathf.PI * value *
                                                              (2.5f * value * value * value +
                                                               0.2f)) +
                                                          Mathf.Pow(1f - value, 2.2f) *
                                                          (Mathf.PI *
                                                           (2.5f * value * value * value + 0.2f) +
                                                           7.5f * Mathf.PI * value * value *
                                                           value) *
                                                          Mathf.Cos(
                                                              Mathf.PI * value *
                                                              (2.5f * value * value * value +
                                                               0.2f)) + 1f) -
                   6f * end * (Mathf.Pow(1 - value, 2.2f) *
                               Mathf.Sin(Mathf.PI * value * (2.5f * value * value * value + 0.2f)) +
                               value
                               / 5f);
        }

        public static float Ease(float value, Easing type, float start = 0, float end = 1)
            => GetEasingFunction(type)(value, start, end);

        public delegate float Function(float v, float s = 0, float e = 1);

        /// <summary>
        /// Returns the function associated to the easingFunction enum. This value returned should be cached as it allocates memory
        /// to return.
        /// </summary>
        /// <param name="easingFunction">The enum associated with the type function.</param>
        /// <returns>The type function</returns>
        public static Function GetEasingFunction(Easing easing) =>
            easing switch
            {
                Easing.Linear => Linear,
                Easing.SineIn => SineIn,
                Easing.SineOut => SineOut,
                Easing.SineInOut => SineInOut,
                Easing.QuadIn => QuadIn,
                Easing.QuadOut => QuadOut,
                Easing.QuadInOut => QuadInOut,
                Easing.CubicIn => CubicIn,
                Easing.CubicOut => CubicOut,
                Easing.CubicInOut => CubicInOut,
                Easing.QuartIn => QuartIn,
                Easing.QuartOut => QuartOut,
                Easing.QuartInOut => QuartInOut,
                Easing.QuintIn => QuintIn,
                Easing.QuintOut => QuintOut,
                Easing.QuintInOut => QuintInOut,
                Easing.ExpoIn => ExpoIn,
                Easing.ExpoOut => ExpoOut,
                Easing.ExpoInOut => ExpoInOut,
                Easing.CircIn => CircIn,
                Easing.CircOut => CircOut,
                Easing.CircInOut => CircInOut,
                Easing.BackIn => BackIn,
                Easing.BackOut => BackOut,
                Easing.BackInOut => BackInOut,
                Easing.ElasticIn => ElasticIn,
                Easing.ElasticOut => ElasticOut,
                Easing.ElasticInOut => ElasticInOut,
                Easing.BounceIn => BounceIn,
                Easing.BounceOut => BounceOut,
                Easing.BounceInOut => BounceInOut,
                Easing.Spring => Spring,
                _ => null
            };

        /// <summary>
        /// Gets the derivative function of the appropriate type function. If you use an type function for position then this
        /// function can get you the speed at a given time (normalized).
        /// </summary>
        /// <param name="easingFunction"></param>
        /// <returns>The derivative function</returns>
        public static Function GetEasingFunctionDerivative(Easing easing) =>
            easing switch
            {
                Easing.Linear => LinearD,
                Easing.SineIn => SineInD,
                Easing.SineOut => SinceOutD,
                Easing.SineInOut => SineInOutD,
                Easing.QuadIn => QuadInD,
                Easing.QuadOut => QuadOutD,
                Easing.QuadInOut => QuadInOutD,
                Easing.CubicIn => CubicInD,
                Easing.CubicOut => CubicOutD,
                Easing.CubicInOut => CubicInOutD,
                Easing.QuartIn => QuartInD,
                Easing.QuartOut => QuartOutD,
                Easing.QuartInOut => QuartInOutD,
                Easing.QuintIn => QuintInD,
                Easing.QuintOut => QuintOutD,
                Easing.QuintInOut => QuintInOutD,
                Easing.ExpoIn => ExpoInD,
                Easing.ExpoOut => ExpoOutD,
                Easing.ExpoInOut => ExpoInOutD,
                Easing.CircIn => CircInD,
                Easing.CircOut => CircOutD,
                Easing.CircInOut => CircInOutD,
                Easing.BackIn => BackInD,
                Easing.BackOut => BackOutD,
                Easing.BackInOut => BackInOutD,
                Easing.ElasticIn => ElasticInD,
                Easing.ElasticOut => ElasticOutD,
                Easing.ElasticInOut => ElasticInOutD,
                Easing.BounceIn => BounceInD,
                Easing.BounceOut => BounceOutD,
                Easing.BounceInOut => BounceInOutD,
                Easing.Spring => SpringD,
                _ => null
            };
    }
}
