<script lang="ts">
    import { Button } from "$lib/components/ui/button";
    import { Input } from "$lib/components/ui/input/index.js";
    import { Checkbox } from "$lib/components/ui/checkbox/index.js";
    import { Label } from "$lib/components/ui/label/index.js";
</script>

    <div class="shadow-xl max-w-md bg-white p-8 rounded-lg w-full">
        <div class="flex flex-col items-center">
            <h1 class="mb-6 text-2xl font-bold">AppDNO</h1>
            <div class="w-full flex flex-col items-center gap-4 mb-6">
                <Input
                    type="email"
                    placeholder="Email"
                    class="w-full h-12 text-lg"
                />
                <Input
                    type="password"
                    placeholder="Mot De Passe"
                    class="w-full h-12 text-lg"
                />
            </div>
        </div>
        <div class="w-full flex items-start justify-between">
            <div class="flex flex-col items-start">
                <div class="flex items-center space-x-2">
                    <Checkbox id="stay-connected" />
                    <Label
                        for="stay-connected"
                        class="text-sm font-medium leading-none peer-disabled:cursor-not-allowed peer-disabled:opacity-70"
                    >
                        Rester connecté
                    </Label>
                </div>
                <a href="#" class="text-xs text-blue-600 hover:underline mt-2">Mot de passe oublié ?</a>
            </div>
            <Button class="ml-4 h-12 px-8 bg-green-600">Connexion</Button>
        </div>
    </div>

