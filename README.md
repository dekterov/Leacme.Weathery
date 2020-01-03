# Leacme.Weathery

**Leacme Weathery** is a cross-platform desktop application able to run on Windows, MacOS, and Linux. It is build using [Microsoft .NET](https://github.com/dotnet/core) platform and [Avalonia UI](https://github.com/AvaloniaUI/Avalonia) framework.

This application features the ability to retrieve the weather forecast for a location.

![][image_screenshot]
![index](https://user-images.githubusercontent.com/6654513/71704355-168ef280-2d97-11ea-9f26-961a66dc6405.png)

## Application Compiling

The desktop application can be compiled into an executable with [.NET 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1) by navigating to `Leacme.App.Weathery` folder and running:
```
dotnet publish --configuration Release -p:CopyOutputSymbolsToPublishDirectory=false -p:PublishSingleFile=true -p:LeacmeOutputType=winexe --runtime win-x64
```
Note: `win-x64` can be replaced with other runtimes such as `linux-x64`, or `osx-x64`, for more runtimes see [RID Catalog](https://docs.microsoft.com/en-us/dotnet/core/rid-catalog)

## Application Usage

Enter the name of the location for which you want to retrieve the weather forecast. Select the desired number of days and the units for the forecast data and click Get Weather.

## Library Usage

The applicatin library can also be build and used separately by navigating to `Leacme.Lib.Weathery` folder and running `dotnet build`. This will create a .dll library that can be copied into the directory where your .csproj is located. Be sure as well to add the following line to your .csproj file to point to the location of the library:
```
<ItemGroup><Reference Include="Leacme.Lib.Weathery.dll"><HintPath>Leacme.Lib.Weathery.dll</HintPath></Reference></ItemGroup>
```
It can then be added and used within your project with `var library = new Leacme.Lib.Weathery.Library();`

## Copyright
[(c) 2017 Leacme](http://leac.me)

## Contact
The author can be contacted via the contact form on their website http://leac.me

## License
View [LICENSE.md](LICENSE.md) for more information

[image_screenshot]:
data:image/png;base64,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Pn26Ei/A6dOnee+993B2dmbChAmEhYUp2+Lj45k/fz4NGzakc+fOXLx4UdmWsQd0//79TJo0Kcd979+/j7e3N25ubnz22WfMnz+fdevW5bsNjx49wsPDg+3bt9OhQwemTZsGwO3bt/n4449xcXGhX79+XLp0STkmOjqamTNn0rhxYzp06MDOnTvzXS+Aqakpbdu2xcfHR1mXkpLC+vXrad++PR4eHixevJjnz59ne3zG89WzZ88sPeL+/v55tiWz48eP59g7qFKpcHR0pFWrVvnu5e7Xrx9BQUH8+eefbNq0ifLly9O+fXtlu7u7O506dWLp0qVcuHCBXbt28b///U/Zvnt4c5XMAAAgAElEQVT3boYNG4aDgwOlSpVixIgRbNu2Tae6fX196dixI02bNsXS0pJhw4axdOlSpZc7r7KrVKnC9evXC2TYo7W1NY0aNeLbb79l4cKFys9v7dq1GBoaYmNjQ48ePfjrr7+AtPdDs2bNtP6OREVFUb16dWJiYkhMTGTWrFnUr1+fd955hz/++OOlYxSvp0ePHtGsWTN++eUXOnbsSIsWLdixY4ey/fDhw3zxxRcA9OjRgxs3bijXnfv37/PgwQNGjhxJ7dq1GTRoEFevXs2zzr///jvL4x091hxm9+Wsfx92XbpPjzWHtdY5Ozvz999/51h+9+7d+fnnn5XejIMHD/L+++9r7ZOSksLGjRvp1KkTzZo1Y8mSJcrfzOzamfGa2KxZM3bv3q11biAt4R09ejT169dn5MiRPH78WOf250de7U934MABJk6cyOzZs/Hw8KB79+7cvHmTzZs307RpU7y8vLSu+3PmzGHlypWMGjUKd3d3xo8fT0REhLL9zp07jBo1CldXVwYOHKh1oz27z0ALFy5UbiSfP39eOZ9t27Zl3bp1L5TovIrkKzExka+++ooZM2bQsmVLrKysMDY2plq1akyePBkLCwvUajVJSUls3ryZd999lzZt2rB06VISEhJQq9V88MEHBAYGYmVlhZWVFffv39eqQ6VS4eXlxZUrV1Cr1URFRSmjoDKu27VrFzVq1FBez507F09PT9577z3++OMPpbzz588rdXXq1IkNGzaQkpKSayzx8fEsWrSIVq1a8f777xMQEKCUl1tdBw8eZOrUqSxatIg2bdqwZ88eSYwFIInxa2/FihV4eHjg6+vLsGHDmDx5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ueeeWbJkye/kep06dcqTTz75Oxl71apV9e9QnjBhwnse/9xzz+Xpp59Oly5dtnh96dKlufLKK3PFFVfk4YcfTs+ePd9zzvPmzcuZZ5653Sd477HHHvnpT39a337ggQdy1FFH7cS7AgAA+HBo2DBetWpVFi9enNNPPz3t27dPx44dc/rpp+fEE09MksyaNSvXXntt/fi33nortVotmzdvTpJ8/etfz3XXXZcxY8bk8MMPz+jRo7Nq1aokyf/8z/+kX79+aWlpyaBBg/IP//APW60Y33rrrTnhhBPSt2/fXHvttfWV2V/+8peZPn16Tj311PTr1y+TJ0/Oxo0bP7D3vXnz5lx55ZW56KKLtto3derUXHrppTniiCPS3Nyck046Kb17997uWBs3bsz06dNz+eWX5+mnn87zzz+/1TEjRozID37wg/r27bffnhEjRnwwbwYAAOAPQMOGcadOnXL88cfnxhtvzIoVK36j3ztvaWnJBRdckKVLl+bAAw/MjTfeWN/30EMPZeXKlbn99tvzta99bYvzXnjhhdxwww2ZOXNm7r///nziE5+or8zefPPNWbp0aW666abcd999WbNmTW655Zb6ucOHD8/8+fO3GG/w4MHp3bt3xo0bl5deeqn++uuvv55arZaf//zn9dfmzJmTvn37brVavGnTpsycOTNr1qzJCSeckGOOOSZTp07Npk2btvv+lyxZkkMPPTTdu3fPX/7lX+a+++7b6pjjjjsud999dzZs2JCXX345a9asyWGHHbajjxUAAOBDpWHDeLfddsutt96a1atXZ8SIEfXV2XXr1u30GF/84hfTrVu3tGvXLoMGDdri14732muvnHvuuWnfvv1W5+2yyy5p3759dt9997Rv3z6nnHJKfWV22rRpufDCC7P//vtnr732ype//OXccccd253Dk08+mZ/85Cd54IEHcuCBB+bcc8/d7n3Sq1atyi233JJRo0ZttW/NmjX5xS9+kYULF2bOnDmZM2dOfvzjH2fWrFnbvfZdd92VYcOGJUkGDhyYW265pb6i/q527drlM5/5TB588MHMmzcvI0eO3O54AAAAH0YNG8ZJ0rlz54wfPz4PPvhg7rzzzixfvjyTJk3a6fP33Xff+s+77bZb1q9fX9/u0aNHmpubt3lely5dMnbs2Fx++eU577zzMmvWrGzcuDEbNmzIww8/nD/7sz9Lx44d09zcnI997GNZtGhR/dyWlpZ86lOf2mrMffbZJ1/5ylfy2muvZdmyZfX5VVWVAw44IEly9dVXZ+zYsdl99923On+33XZLkpx11lnp0KFD9t9//4waNSoLFy7c5nt49dVX873vfS/HH398kqR3797ZtGlTli5dutWxp512WmbPnp1Zs2bl5JNP3uZ4AAAAH1YNHcatHXDAARkxYkQ9Qpubm7e4t/f9rCQnSa1W2+H+E088MVOmTMnVV1+dZ555JjNnzszuu++ePn365PHHH8+rr76ajRs3pqqqrF27dqev+84772x335IlSzJgwID6E6xffPHFHHrooWlpaUmHDh3Sv3//rc75yEe2/Ve4YMGCrFu3Lh//+MdTq9XS1NSUhx9+eIv7id/Vo0ePrF69Op/85CfToUOHnX4vAAAAHwYNG8Yvv/xyJk6cmGXLlmXjxo1ZuXJlWlpa6nF44IEH5t57783KlSuzdu3aXHfddR/YtR9++OH867/+a1577bVs3rw5VVXVf/35/PPPz7e//e2sWLEib7/9dv7rv/4r06ZNq5/b+h7jRx55JHPnzs3rr79en2PHjh1z8MEHJ9n6HuP/+I//qD+9uqqqdOnSJc8880yGDx+eJPnSl76U6dOn57XXXsuqVasyY8aMDBw4cJvvoaWlJXPnzt1ivKeffjo33njjNv8TYc6cObnyyis/sM8QAADgD0XDhnHnzp3Tv3//XHXVVenVq1dGjhyZj370o7n44ouTJL169crQoUMzaNCgjBo1KkcfffQHdu1evXrlrbfeyvDhw3Pcccelqqp84QtfSJKMGjUqRx55ZEaPHp2+ffvm1ltvzeDBg7c5Ts+ePfP6669n+PDhOfnkk/Ozn/0s119/fdq1a/cbzWvUqFHp3r17jj/++Jxxxhk57rjjcsYZZ2x13LPPPpuHH344J5100havH3rooTn22GPzox/96De6PgAAwIdRbezYsdVFF41Lkuyzz77vcfjvxjXXXJNLLrmkTa4NAABA25g4cWIuuOCCNrn2G2+8niS56qpvN+6KMQAAAPw+CGMAAACKJowBAAAomjAGAACgaA0dxsuWLcuYMWPSs2fPDBkyJDNmzKh/bVJbmD9/fsaPH7/DY+bMmVP/HuJ3/yxfvny7x7/wwgsZN25cDj/88AwbNiz33XffFvtff/31TJgwIYcffniGDx+exx9/fLtjff7zn69f85hjjsk3v/nNvPnmm0mS7373u6nValmwYMEW58yYMSO1Wi133XXXe7x7AACAD6ctwrj1d97+Pv9sy6ZNm3L22Wenf//+eeihhzJ9+vTsueeeWbJkye/lg/ltTJo0aYv317Vr1+0ee/fdd+fss8/OI488kgkTJuTCCy/MU089leRXfx/jxo1Lhw4dsmjRokybNi0/+clPdnjthQsXpqqq3HnnnXn++edzww031Pf9xV/8Re688876dlVVmTVrVv17kgEAAH7fGqFDG3bFeNWqVVm8eHFOP/30tG/fPh07dszpp5+eE088MUkya9asXHvttfXj33rrrdRqtWzevDlJ8vWvfz3XXXddxowZk8MPPzyjR4/OqlWrkiRvv/12vva1r6V3794ZNGhQ/u3f/q0+zhtvvJEJEyakb9++GTRoUObOnZskeemll3LKKafkm9/8Zmq1Wvr16/eBvM9359fc3JzDDz88J510Ul544YUkydKlS7N69ep85StfSYcOHbLffvvlr/7qr3Zq3E6dOuXUU0/NT3/60/prxx57bJYvX56VK1cmSR577LH06NFjh+EOAADwYdewYdypU6ccf/zxufHGG7NixYrtrizvSEtLSy644IIsXbo0Bx54YG688cYkyb//+7/nzTffzKJFi3LbbbdlxYoVWb9+faqqyiWXXJKOHTtmwYIF+d73vpcZM2bkkUceycc//vHcd999ufTSS1NVVX3letGiRfnUpz61xXVnzJiRrl27ZsiQIZk9e/YWcx8+fHjmz5+/1VzfeeedPPXUU3n00UfTs2fPJMmTTz6Z3r17Z/z48enevXvOOuusLUJ3R1555ZXMmzcvPXr0qL9Wq9UycuTI+q9r33333Rk6dOj7+EQBAAA+fBo2jHfbbbfceuutWb16dUaMGJF+/fpl8uTJWbdu3U6P8cUvfjHdunVLu3btMmjQoDz55JNJkqamprRr1y7t2rVLhw4dMnr06LRv3z4vvvhili5dmr/+67/OHnvskc6dO+ecc87J/fffv9PXHDZsWJ544oksW7Ys3/rWt/LP//zPW6xIb8t3v/vd7LLLLundu3cuuOCCfOxjH0uSrFy5Mv/0T/+U0047Lf/93/+dESNG5KyzztrhZ3DiiSemVqvlM5/5TLp27brVCvMpp5ySWbNmZe3atbn//vvTt2/fnX5vAAAAH0YNG8ZJ0rlz54wfPz4PPvhg7rzzzixfvjyTJk3a6fP33Xff+s+77bZb1q9fnyQ59dRT071795x33nkZN25cFi5cmORXq6yPPPJIOnXqlL333jvNzc0ZPHhwVqxYsd1rHHfccdtcAW5qasphhx2Wv/3bv91if0tLy1YrzH/zN3+TX/7yl3nqqady00031R+Q1dzcnGHDhmXAgAFp165dBg8enI4dO+aZZ57Z7nzevcd4yZIlueyyy7LXXnttsb9Tp0455JBDMnHixJxxxhnZddddtzsWAABACZraegI764ADDsiIESPqT4Vubm7Oxo0b6/vfz0ryrrvumjPPPDNnnnlmXn311Zxzzjn1e3gHDhyY+fPnp1arbXXetl7bGTtz3i677JKDDjooQ4YMyWOPPZaBAwfm4IMPzqOPPvqBzeNdQ4cOzYknnphly5b9VuMAAAB8GDTsivHLL7+ciRMnZtmyZdm4cWNWrlyZlpaW9O/fP0ly4IEH5t57783KlSuzdu3aXHfddTs99uzZs7N48eKsX78+77zzTt555528/fbb6dq1a7p165brr78+b7zxRtatW5cf/vCHueeee5L8agX6+eef3+Iro379HuMpU6bkueeey8aNG/PUU09l6tSpOfnkk+v7W99jvG7dukyZMiX/+7//m02bNuXpp5/OHXfckV69eiX51cOyHnvssfzoRz/Kxo0bc88992Tt2rX5xCc+8Zt/sElOOOGEVFWVbt26/VbjAAAAfBg0bBh37tw5/fv3z1VXXZVevXpl5MiR+ehHP5qLL744SdKrV68MHTo0gwYNyqhRo3L00Ufv9NgDBw7MAw88kGOPPTYjRozIZz/72fz5n/95arVaJk2alDVr1mTIkCEZPHhwHn/88QwYMKB+za5du6Znz57bfSr1pz/96VxzzTXp06dPxo8fny9/+csZMmTINo/da6+9csQRR+TCCy/MYYcdlssvvzyjR4+uh/Y+++yT2267LdOmTUuPHj1yxx13ZPr06dljjz3ez0cJAADADtTGjh1bXXTRuCTJ3nvv0yaTuPbaa3PJJZe0ybUBAABoGxMnTsyYMWPa5Npr176RJLnqqm837ooxAAAA/D4IYwAAAIomjAEAACiaMAYAAKBowhgAAICiCWMAAACK1tR6o6qqtpoHAAAABWqEDrVi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
