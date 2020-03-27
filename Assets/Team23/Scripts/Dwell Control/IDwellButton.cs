using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDwellButton
{
    float getDwellTime();
    void unselected();
    void selected();
}
